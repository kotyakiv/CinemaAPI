namespace CinemaAPI.Models
{
    public class CinemasItem
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required int OpeningHour { get; set; }
        public required int ClosingHour { get; set; }
        public required int ShowDuration { get; set; }

        public static List<int[]> showTimeTable(int open, int close, int length)
        {
            const int SESSION_GAP = 15;
            int duration;
            int sessionNum;


            if (open == 24) open = 0;
            if (close == 24) close = 0;

            if (open < close)
                duration = close - open;
            else if (open > close)
                duration = 24 - open + close;
            else
                duration = 0;

            length += SESSION_GAP;
            sessionNum = duration * 60 / length;


            List<int[]> showTimeTable = new List<int[]>();
            int hours;
            int minutes;

            hours = open;
            minutes = 0;
            for (int i = 0; i < sessionNum; i++)
            {
                int[] showStartTime = new int[2];
                showStartTime[0] = hours;
                showStartTime[1] = minutes;

                hours += length / 60;
                minutes += length % 60;
                if (minutes >= 60)
                {
                    minutes -= 60;
                    hours += 1;
                }
                if (hours >= 24)
                    hours -= 24;

                showTimeTable.Add(showStartTime);
            }

            return showTimeTable;
        }
    }
}
