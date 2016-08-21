using System;

namespace Algorithm
{
    public class FinderResult
    {
        public Person PersonWithEarliestBirthDate { get; set; }
        public Person PersonWithMostCurrentBirthDate { get; set; }
        public TimeSpan TimeBetweenBirthdays { get; set; }
    }
}