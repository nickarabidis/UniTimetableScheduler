using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduler.Model
{
    public class Criteria
    {
        //Commented Code for classes in same semester to not have more than one class at the same time, day, semester

        //internal static bool IsSemesterOverlapped(List<CourseClass>[] slots, Reservation reservation, int dur)
        //{
        //    // check for semester overlapping of classes
        //    for (int i = dur - 1; i >= 0; i--)
        //    {
        //        if (slots[reservation.GetHashCode() + i].Count > 1)
        //            return true;
        //    }
        //    return false;
        //}

        internal static bool IsSemesterOverlapped(List<CourseClass>[] slots, Reservation reservation, int dur)
        {
            // check for semester overlapping of classes
            for (int i = dur - 1; i >= 0; i--)
            {
                var classesAtSlot = slots[reservation.GetHashCode() + i];

                // Check if there are more than one class at the slot
                if (classesAtSlot.Count > 1)
                {
                    // Check if all classes at the slot are labs
                    if (classesAtSlot.All(courseClass => courseClass.LabRequired && (courseClass.HowManyDays == 1)))
                    {
                        // All classes at the slot are labs, so it's allowed
                        continue;
                    }
                    else
                    {
                        // There's at least one class that is not a lab, overlapping is not allowed
                        return true;
                    }
                }
            }

            return false;
        }


        internal static bool[] IsOverlappedProfAndRoom(List<CourseClass>[] slots, CourseClass cc, int numberOfSemesters, int timeId)
        {
            bool po = false, go = false;

            int dur = cc.Duration;
            // check overlapping of classes for professors and rooms
            for (int i = numberOfSemesters; i > 0; --i, timeId += Constant.DAY_HOURS)
            {
                // for each hour of class
                for (int j = dur - 1; j >= 0; --j)
                {
                    // check for overlapping with other classes at same time
                    var cl = slots[timeId + j];
                    foreach (var cc1 in cl)
                    {
                        if (cc != cc1)
                        {
                            // professor overlaps?
                            if (!po && cc.ProfessorOverlaps(cc1))
                                po = true;

                            // room overlaps?
                            if (!go && cc.RoomOverlaps(cc1))
                                go = true;

                            // both type of overlapping? no need to check more
                            if (po && go)
                                return new bool[] { po, go };
                        }
                    }
                }
            }

            return new bool[] { po, go };
        }

        public static bool IsOverlappedMeetingProf(List<CourseClass>[] slots, CourseClass cc, int day, int time)
        {
            bool to = false;
            int dur = cc.Duration;

            if (cc.Professor.Meeting == true && day == 3)
            {
                for (int i = time; i < time + dur; i++)
                {
                    if (i == 2 || i == 3)
                    {
                        to = true;
                        return to;
                    }
                }
            }

            return to;
        }

        public static bool IsAtLeastOneFreeHour(List<CourseClass>[] slots, int numberOfSemesters)
        {
            //int totalTimes = Constant.DAY_HOURS;
            int totalDays = Constant.DAYS_NUM;
            int timeStartFree = 4;
            int timeEndFree = 8;
            bool fh = false;

            for (int semester = 0; semester < numberOfSemesters; semester++)
            {
                for (int day = 0; day < totalDays; day++)
                {
                    bool dayOccupied = true;

                    for (int time = timeStartFree; time < timeEndFree; time++)
                    {
                        int slotHash = Reservation.HashCode(day, time, semester);
                        //Console.WriteLine("slotshash : " + slotHash);
                        //Console.WriteLine("slots : " + slots[slotHash]);

                        if (slots[slotHash] != null && slots[slotHash].Count == 0)
                        {
                            dayOccupied = false;
                            break;
                        }

                        foreach (CourseClass cc1 in slots[slotHash])
                        {
                            if (cc1.LabRequired == true)
                            {
                                dayOccupied = false;
                                break;
                            }
                        }

                        if (!dayOccupied)
                        {
                            break;
                        }
                    }

                    if (dayOccupied)
                    {
                        fh = true;
                        return fh;
                    }
                }
            }

            return fh;
        }

        public static bool IsAtLeastOneClass(List<CourseClass>[] slots, int numberOfSemesters)
        {
            int totalTimes = Constant.DAY_HOURS;
            int totalDays = Constant.DAYS_NUM;
            bool atLeastOneClass = false;

            for (int semester = 0; semester < numberOfSemesters; semester++)
            {
                for (int day = 0; day < totalDays; day++)
                {
                    bool dayOccupied = false;

                    for (int time = 0; time < totalTimes; time++)
                    {
                        
                        int slotHash = Reservation.HashCode(day, time, semester);
                        //Console.WriteLine("slotshash : " + slotHash);
                        //Console.WriteLine("slots : " + slots[slotHash]);
                        if (slots[slotHash] != null && slots[slotHash].Count > 0)
                        {
                            dayOccupied = true;
                            break;
                        }
                    }

                    if (!dayOccupied)
                    {
                        atLeastOneClass = true;
                        return atLeastOneClass;
                    }
                }
            }

            return atLeastOneClass;
        }

        //public static bool IsDependencySameOrDifferentDay(List<CourseClass>[] slots, CourseClass cc, int numberOfSemesters, int dayId, int daySize)
        //{
        //    bool dpSameOrDiff = false;
        //    int course = cc.Course.Id;
        //    List<Course> dependency = cc.Dependencies;
        //    bool sameDay = cc.SameDay;
        //    bool differentDay = cc.DifferentDay;

        //    if (!sameDay && !differentDay)
        //    {
        //        return false;
        //    }
        //    //Console.WriteLine("Dependency: " + dependency);
        //    if (dependency != null && dependency.Count > 0)
        //    {
        //        //Console.WriteLine("course: " + course);
        //        foreach (Course dependencies in dependency)
        //        {
        //            int dependentCourses = dependencies.Id;
        //            //Console.WriteLine("Dependency: " + dependentCourses);
        //            bool sameDayMet = false;

        //            for (int i = dayId; i < dayId + daySize; i++)
        //            {
        //                List<CourseClass> cl = slots[i];

        //                foreach (CourseClass cc1 in cl)
        //                {
        //                    //Console.WriteLine("COURSEID: " + cc1.Course.Id);
        //                    if (cc != cc1)
        //                    {
        //                        if (sameDay)
        //                        {
        //                            dpSameOrDiff = true;
        //                            //Console.WriteLine("DependentCourse: " + dependentCourses);
        //                            //Console.WriteLine("Course of cc1: " + cc1.Course.Id);
        //                            //Console.WriteLine("WHAT BOOL: " + (dependentCourses == cc1.Course.Id));
        //                            if (dependentCourses == cc1.Course.Id)
        //                            {
        //                                //Console.WriteLine("WENT IN ");
        //                                sameDayMet = true;
        //                                break;
        //                            }
        //                        }
        //                        else if (differentDay)
        //                        {
        //                            if (dependentCourses == cc1.Course.Id)
        //                            {
        //                                dpSameOrDiff = true;

        //                            }
        //                        }
        //                    }
        //                }
        //                if (sameDayMet)
        //                {
        //                    break;
        //                }
        //            }
        //            //Console.WriteLine("sameDay && sameDayMet: " + (sameDay && sameDayMet));
        //            if (sameDay && sameDayMet)
        //            {

        //                dpSameOrDiff = false;
        //            }
        //        }
        //    }
        //    //Console.WriteLine("dpSameOrDiff: " + dpSameOrDiff);
        //    return dpSameOrDiff;
        //}

        public static bool IsDependencySameOrDifferentDay(List<CourseClass>[] slots, CourseClass cc, int numberOfSemesters, int dayId, int daySize)
        {
            bool dpSameOrDiff = false;
            //int course = cc.Course.Id;
            List<int> dependency = cc.Dependencies;
            int howManyDays = cc.HowManyDays;
            //bool sameDay = cc.SameDay;
            //bool differentDay = cc.DifferentDay;

            //if (!sameDay && !differentDay)
            //{
            //    return false;
            //}
            //Console.WriteLine("Dependency: " + dependency);
            if (dependency != null && dependency.Count > 0)
            {
                //Console.WriteLine("course: " + course);
                foreach (int dependencies in dependency)
                {
                    //int dependentCourses = dependencies;
                    //Console.WriteLine("Dependency: " + dependentCourses);
                    bool sameDayMet = false;

                    for (int i = dayId; i < dayId + daySize; i++)
                    {
                        List<CourseClass> cl = slots[i];

                        foreach (CourseClass cc1 in cl)
                        {
                            //Console.WriteLine("COURSEID: " + cc1.Course.Id);
                            if (cc != cc1)
                            {
                                if (howManyDays == 1)
                                {
                                    dpSameOrDiff = true;
                                    //Console.WriteLine("DependentCourse: " + dependentCourses);
                                    //Console.WriteLine("Course of cc1: " + cc1.Course.Id);
                                    //Console.WriteLine("WHAT BOOL: " + (dependentCourses == cc1.Course.Id));
                                    if (dependencies == cc1.SchedulerId)
                                    {
                                        //Console.WriteLine("WENT IN ");
                                        sameDayMet = true;
                                        break;
                                    }
                                }
                                else if (howManyDays == 5)
                                {
                                    if (dependencies == cc1.SchedulerId)
                                    {
                                        dpSameOrDiff = true;

                                    }
                                }
                            }
                        }
                        if (sameDayMet)
                        {
                            break;
                        }
                    }
                    //Console.WriteLine("sameDay && sameDayMet: " + (sameDay && sameDayMet));
                    if (howManyDays == 1 && sameDayMet)
                    {

                        dpSameOrDiff = false;
                    }
                }
            }
            //Console.WriteLine("dpSameOrDiff: " + dpSameOrDiff);
            return dpSameOrDiff;
        }

        public static bool IsDependencyInHowManyDays(List<CourseClass>[] slots, CourseClass cc, int numberOfSemesters, int day)
        {
            int totalTimes = Constant.DAY_HOURS;
            int totalDays = Constant.DAYS_NUM;
            bool dpHowManyDays = false;
            int course = cc.Course.Id;
            List<int> dependency = cc.Dependencies;
            int howManyDays = cc.HowManyDays;
            List<int> daysList = new List<int>();

            daysList.Add(day);

            if (howManyDays >= 2 && howManyDays <= 4 && (dependency != null && dependency.Count > 0))
            {
                foreach (int dependencies in dependency)
                {
                    //int dependentCourses = dependencies.Id;

                    for (int slotHash = 0; slotHash < numberOfSemesters * totalDays * totalTimes; slotHash++)
                    {
                        List<CourseClass> cl = slots[slotHash];

                        foreach (CourseClass cc1 in cl)
                        {
                            if (dependencies == cc1.SchedulerId)
                            {
                                Reservation reservation = Reservation.GetReservation(slotHash);
                                int d = reservation.Day;

                                if (!daysList.Contains(d))
                                {
                                    daysList.Add(d);
                                }
                            }
                        }
                    }
                }
                if (daysList.Count != howManyDays)
                {
                    dpHowManyDays = true;
                }
                else
                {
                    dpHowManyDays = false;
                }
            }

            return dpHowManyDays;
        }



        //public static readonly float[] Weights = { 0f, 0f, 0f, 0f, 0f, 0f, 0f };
        public static readonly float[] Weights = { 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };
    }
}
