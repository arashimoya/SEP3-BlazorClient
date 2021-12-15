using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ABDOTClient.Model
{
    public class Hall
    {
        
    
        public int Id { get; set; }

       

        [Required]
        public Branch Branch { get; set; }
        public List<Play> Programme { get; set; }
        
        
        //generated in the constructor
        public List<Tuple<int, int>> Seats { get; set; }

        public Hall() {
            Seats = new List<Tuple<int, int>>();
            Programme = new List<Play>();
        }

        private void CreateSeats(int rows, int columns)
        {
            for (int i = 1; i <= rows; i++)
            {
                for (int z = 1; z <= columns; z++)
                {
                    Tuple<int, int> tuple = new Tuple<int, int>(i, z);
                    Seats.Add(tuple);
                }
            } 
        }



        public void LoadSeats() {
            CreateSeats(6, 8);
        }

        public override string ToString()
        {
            string returnString = "Hall{\nId : " + Id +  "\nProgramme : " + Programme +
                                  "\nBranch : " + Branch + "\nSeats : " + Seats + "\n}";
            return returnString;
        }
    }
}