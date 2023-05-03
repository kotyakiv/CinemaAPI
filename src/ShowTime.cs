namespace CinemaAPI.src
{
    public class ShowTime
    {
        public static bool IsTimeOutOfRange(int open, int close, int length)
        {
            return (open < 0 || open > 24 || close < 0 || close > 24 || length < 0);
        }

        public static List<int[]> ShowTimeTable(int open, int close, int length)
        {
            const int SESSION_GAP = 15;
            List<int[]> showTimeTable = new List<int[]>();
            int duration;
            int sessionNum;
            int hours;
            int minutes;
            

            if (IsTimeOutOfRange(open, close, length))
                return showTimeTable;

            if (open == 24) open = 0;
            if (close == 24) close = 0;

            if (open < close)
                duration = close - open;
            else if (open > close)
                duration = 24 - open + close;
            else
                duration = 0;

            length += SESSION_GAP;
            // There is no break between sessions, when the last movie ends
            sessionNum = (duration * 60 /*+ SESSION_GAP*/) / length;



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
