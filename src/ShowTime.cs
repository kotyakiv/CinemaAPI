namespace CinemaAPI.src
{
    public class ShowTime
    {
        /* 
         * Time cannot be negative; 
         * there is not more than 24 hours; 
         * Opening and closing hours aren't equal, otherwise it's open around the clock;
         */
        public static bool IsTimeInvalid(int open, int close, int length)
        {
            if (open == 24) open = 0;
            if (close == 24) close = 0;

            return (open < 0 || open > 24 || close < 0 || close > 24 || length < 0 || open == close);
        }

        public static List<int[]> ShowTimeTable(int open, int close, int length)
        {
            const int SESSION_GAP = 15;
            List<int[]> showTimeTable = new List<int[]>();
            int durationHours;
            int sessionNum;
            int hours;
            int minutes;
            

            if (IsTimeInvalid(open, close, length))
                return showTimeTable;

            if (open < close)
                durationHours = close - open;
            else if (open > close)
                durationHours = 24 - open + close;
            else
                durationHours = 0;

            length += SESSION_GAP;
            // There is no break between sessions, when the last movie ends, so added SESSION_GAP
            sessionNum = (durationHours * 60 + SESSION_GAP) / length;

            hours = open;
            minutes = 0;
            for (int i = 0; i < sessionNum; i++)
            {
                int[] showStartTime = new int[2];
                showStartTime[0] = hours;
                showStartTime[1] = minutes;

                showTimeTable.Add(showStartTime);

                hours += length / 60;
                minutes += length % 60;
                if (minutes >= 60)
                {
                    minutes -= 60;
                    hours += 1;
                }
                if (hours >= 24)
                    hours -= 24;
            }

            return showTimeTable;
        }
    }
}
