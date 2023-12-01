using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Scheduler.Model;

namespace Scheduler.WinForm
{
    public class HtmlOutput1
    {
        private const int SEMESTER_COLUMN_NUMBER = Constant.DAYS_NUM + 1;
        private const int SEMESTER_ROW_NUMBER = Constant.DAY_HOURS + 1;

        private const string COLOR1 = "#319378";
        private const string COLOR2 = "#CE0000";

        //private static string[] CRITERIAS = { "S" };
        private static string[] CRITERIAS = { "S", "P", "R", "T", "F", "C", "DD", "DH" };
        private static string[] CRITERIAS_DESCR = { "Class per semester has {0} overlapping", "Professors have {0} overlapping", "Rooms have {0} overlapping",
            "If Monimos it is {0}t in 10-12 timeSlot", "Theres at least {0} free timeslot from 12-16", "Theres at least {0} class every day", "Dependencies are{0} in same or different day", "Dependencies are{0} in that many days" };
        private static string[] PERIODS = { "", "8:00 - 9:00", "9:00 - 10:00", "10:00 - 11:00", "11:00 - 12:00", "12:00 - 13:00", "13:00 - 14:00", "14:00 - 15:00", "15:00 - 16:00", "16:00 - 17:00", "17:00 - 18:00", "18:00 - 19:00", "19:00 - 20:00", "20:00 - 21:00", "21:00 - 22:00" };
        private static string[] WEEK_DAYS = { "MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY" };

        private static string GetTableHeader(Semester semester)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<tr><th style='border: .1em solid black; background-color: #00008B; color: white' scope='col' colspan='2' >Semester: ");
            sb.Append(semester.Name);
            sb.Append("</th>\n");
            foreach (string weekDay in WEEK_DAYS)
                sb.Append("<th style='border: .1em solid black; padding: .25em; width: 15%; background-color: #89cff0' scope='col' colspan='2'>").Append(weekDay).Append("</th>\n");
            sb.Append("</tr>\n");
            return sb.ToString();
        }

        private static Dictionary<Tuple<int, int, int>, string[]> GenerateTimeTable(Schedule solution, Dictionary<Tuple<int, int, int>, int[]> slotTable)
        {
            int numberOfSemester = solution.Configuration.NumberOfSemesters;
            int daySize = Constant.DAY_HOURS * numberOfSemester;

            int ci = 0;
            var classes = solution.Classes;

            var timeTable = new Dictionary<Tuple<int, int, int>, string[]>();

            var twoClasses = new Dictionary<Tuple<int, int, int>, int[]>();
            foreach (var cc in classes.Keys)
            {
                Console.WriteLine(cc.Course.Name);
                // coordinate of time-space slot
                var reservation = Reservation.GetReservation(classes[cc]);
                int dayId = reservation.Day + 1;
                int periodId = reservation.Time + 1;
                int semesterId = reservation.Semester;

                var twoClassesKey = Tuple.Create(periodId, dayId, semesterId);
                var semesterTwoClasses = twoClasses.ContainsKey(twoClassesKey) ? twoClasses[twoClassesKey] : null;
                int classOrder = 1;
                if (semesterTwoClasses == null)
                {
                    classOrder = 1;
                }
                else
                {
                    classOrder = 2;
                }

                var key = Tuple.Create(periodId, semesterId, classOrder);
                var semesterDuration = slotTable.ContainsKey(key) ? slotTable[key] : null;

                if (semesterDuration == null)
                {
                    //key = Tuple.Create(periodId, semesterId, 0);
                    semesterDuration = new int[SEMESTER_COLUMN_NUMBER];
                    slotTable[key] = semesterDuration;
                }
                else
                {
                    //key = Tuple.Create(periodId, semesterId, 1);
                    semesterDuration = new int[SEMESTER_COLUMN_NUMBER];
                    slotTable[key] = semesterDuration;
                }
                semesterDuration[dayId] = cc.Duration;


                for (int m = 1; m < cc.Duration; ++m)
                {
                    var nextRow = Tuple.Create(periodId + m, semesterId, classOrder);
                    if (!slotTable.ContainsKey(nextRow))
                        slotTable.Add(nextRow, new int[SEMESTER_COLUMN_NUMBER]);
                    if (slotTable[nextRow][dayId] < 1)
                        slotTable[nextRow][dayId] = -1;
                }

                //classOrder = 0;
                //key = Tuple.Create(periodId, semesterId, classOrder);

                var semesterSchedule = timeTable.ContainsKey(key) ? timeTable[key] : null;
                var sb = new StringBuilder();
                if (semesterSchedule == null)
                {
                    //key = Tuple.Create(periodId, semesterId, 0);
                    semesterSchedule = new string[SEMESTER_COLUMN_NUMBER];
                    timeTable[key] = semesterSchedule;
                }
                else
                {
                    //key = Tuple.Create(periodId, semesterId, 1);
                    semesterSchedule = new string[SEMESTER_COLUMN_NUMBER];
                    timeTable[key] = semesterSchedule;
                }
                sb.Append(cc.Course.Name).Append("<br />").Append(cc.Professor.Name).Append("<br />").Append(cc.FinalRooms.Name).Append("<br />");
                //sb.Append(string.Join("/", cc.Groups.Select(grp => grp.Name).ToArray()));
                if (cc.LabRequired)
                    sb.Append("Lab<br />");

                //for (int i = 0; i < CRITERIAS.Length; ++i)
                //{
                //    sb.Append("<span style='color:");
                //    if (solution.Criteria[ci + i])
                //    {
                //        sb.Append(COLOR1).Append("' title='");
                //        if (i >= 0 && i <= 5)
                //        {
                //            sb.Append(string.Format(CRITERIAS_DESCR[i], (i == 4 || i == 5) ? "one" : "no"));
                //        }
                //        else if (i == 6 || i == 7)
                //        {
                //            sb.Append(string.Format(CRITERIAS_DESCR[i], ""));
                //        }
                //    }
                //    else
                //    {
                //        sb.Append(COLOR2).Append("' title='");
                //        sb.Append(string.Format(CRITERIAS_DESCR[i], (i == 1 || i == 2) ? "not " : ""));
                //    }
                //    sb.Append("'> ").Append(CRITERIAS[i]);
                //    sb.Append(" </span>");
                //}
                //if (semesterSchedule != null)
                //    semesterSchedule[dayId] += sb.ToString();
                //else
                //    semesterSchedule[dayId] = sb.ToString();
                semesterSchedule[dayId] = sb.ToString();
                //ci += CRITERIAS.Length;
            }
            return timeTable;
        }


        private static string GetHtmlCell(string content, int rowspan, bool twoClasses)
        {
            if (rowspan == 0)
                return "<td colspan='2'></td>";

            if (content == null)
                return "";

            StringBuilder sb = new StringBuilder();
            if (twoClasses)
            {
                if (rowspan > 1)
                    sb.Append("<td style='border: .1em solid black; padding: .25em' colspan='1' rowspan='").Append(rowspan).Append("'>");
                else
                    sb.Append("<td style='border: .1em solid black; padding: .25em' colspan='1'>");
            }
            else
            {
                if (rowspan > 1)
                    sb.Append("<td style='border: .1em solid black; padding: .25em' colspan='2' rowspan='").Append(rowspan).Append("'>");
                else
                    sb.Append("<td style='border: .1em solid black; padding: .25em' colspan='2'>");
            }

            sb.Append(content);
            sb.Append("</td>");
            return sb.ToString();
        }

        public static string GetResult(Schedule solution)
        {
            StringBuilder sb = new StringBuilder();
            int nsemester = solution.Configuration.NumberOfSemesters;

            var slotTable = new Dictionary<Tuple<int, int, int>, int[]>();
            var timeTable = GenerateTimeTable(solution, slotTable); // Point.X = time, Point.Y = semesterId
            if (slotTable.Count == 0 || timeTable.Count == 0)
                return "";

            for (int semesterId = 0; semesterId < nsemester; ++semesterId)
            {
                var semester = solution.Configuration.GetSemesterById(semesterId);
                for (int periodId = 0; periodId < SEMESTER_ROW_NUMBER; ++periodId)
                {
                    bool twoClasses = false;

                    int classOrder = 1;
                    int classOrder2 = 2;
                    
                    var key = Tuple.Create(periodId, semesterId, classOrder);
                    var semesterDuration = slotTable.ContainsKey(key) ? slotTable[key] : null;
                    var semesterSchedule = timeTable.ContainsKey(key) ? timeTable[key] : null;
                    var key2 = Tuple.Create(periodId, semesterId, classOrder2);
                    var semesterDuration2 = slotTable.ContainsKey(key2) ? slotTable[key2] : null;
                    var semesterSchedule2 = timeTable.ContainsKey(key2) ? timeTable[key2] : null;

                    if (semesterDuration2 != null && semesterSchedule2 != null)
                    {
                        twoClasses = true;
                    }
                    else
                    {
                        twoClasses = false;
                    }



                    if (periodId == 0)
                    {
                        sb.Append("<div id='semester_").Append(semester.Name).Append("' style='padding: 0.5em'>\n");
                        sb.Append("<table style='border-collapse: collapse; width: 95%'>\n");
                        sb.Append(GetTableHeader(semester));
                    }
                    else
                    {
                        //var key = new Point(periodId, semesterId);
                        //var semesterDuration = slotTable.ContainsKey(key) ? slotTable[key] : null;
                        //var semesterSchedule = timeTable.ContainsKey(key) ? timeTable[key] : null;
                        sb.Append("<tr>");
                        for (int i = 0; i < SEMESTER_COLUMN_NUMBER; ++i)
                        {
                            if (i == 0)
                            {
                                sb.Append("<th style='border: .1em solid black; padding: .25em' scope='row' colspan='2'>").Append(PERIODS[periodId]).Append("</th>\n");
                                continue;
                            }

                            //if (semesterSchedule == null && semesterDuration == null && semesterSchedule2 == null && semesterDuration2 == null)
                            //    continue;

                            if (!twoClasses) 
                            {
                                if (semesterSchedule == null && semesterDuration == null)
                                    continue;
                                string content = (semesterSchedule != null) ? semesterSchedule[i] : null;
                                sb.Append(GetHtmlCell(content, semesterDuration[i], twoClasses));
                            }
                            else
                            {
                                if (semesterSchedule2 == null && semesterDuration2 == null)
                                    continue;
                                string content2 = (semesterSchedule2 != null) ? semesterSchedule2[i] : null;
                                sb.Append(GetHtmlCell(content2, semesterDuration2[i], twoClasses));
                            }
                            
                        }
                        sb.Append("</tr>\n");
                    }

                    if (periodId == SEMESTER_ROW_NUMBER - 1)
                        sb.Append("</table>\n</div>\n");
                }
                
            }

            return sb.ToString();
        }

    }
}
