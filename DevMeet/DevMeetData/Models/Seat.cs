﻿namespace DevMeetData.Models
{
    public class Seat : IEntity
    {
        public int Id { get; set; }
        public int Column { get; set; }
        public string Row { get; set; }
        public string Name 
        {
            get
            {
                return Row + Column.ToString();
            }
        }
    }
}
