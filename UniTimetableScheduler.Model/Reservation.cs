using System;
using System.Collections.Generic;

namespace Scheduler.Model
{
    public class Reservation
    {
        private static readonly Dictionary<int, Reservation> _reservationPool = new();

        private static int NSemester;
        private readonly int day;
		private readonly int time;
		private readonly int semester;

		public Reservation(int day, int time, int semester)
		{
			this.day = day;
			this.time = time;
			this.semester = semester;
		}

		public int Day { get { return day; } }

        public int Time { get { return time; } }

		public int Semester { get { return semester; } }
        public static Reservation GetReservation(int hashCode)
        {
            Reservation reservation;
            _reservationPool.TryGetValue(hashCode, out reservation);
            if (reservation == null)
            {
                int day = hashCode / (Constant.DAY_HOURS * NSemester);
                int hashCode2 = hashCode - (day * Constant.DAY_HOURS * NSemester);
                int semester = hashCode2 / Constant.DAY_HOURS;
                int time = hashCode2 % Constant.DAY_HOURS;
                reservation = new Reservation(day, time, semester);
                _reservationPool[hashCode] = reservation;
            }
            return reservation;
        }

        public static int HashCode(int day, int time, int semester)
        {
            return day * Constant.DAY_HOURS * NSemester + semester * Constant.DAY_HOURS + time;
        }
        public static Reservation GetReservation(int nsemester, int day, int time, int semester)
        {
            if (nsemester != NSemester && nsemester > 0)
            {
                NSemester = nsemester;
                _reservationPool.Clear();
            }

            int hashCode = HashCode(day, time, semester);
            Reservation reservation = GetReservation(hashCode);
            if (reservation == null)
            {
                reservation = new Reservation(day, time, semester);
                _reservationPool[hashCode] = reservation;
            }
            return reservation;
        }

        public override bool Equals(Object obj)
		{
			//Check for null and compare run-time types.
			if ((obj == null) || !this.GetType().Equals(obj.GetType()))
				return false;

			var other = (Reservation) obj;
			return GetHashCode().Equals(other.GetHashCode());
		}

		public override int GetHashCode()
		{
			return HashCode(day, time, semester);
		}
	}
}
