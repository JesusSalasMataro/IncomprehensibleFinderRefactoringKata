﻿using System.Collections.Generic;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _people;

        public Finder(List<Person> persons)
        {
            _people = persons;
        }

        public FinderResult Find(FindingType findingType)
        {
            List<FinderResult> FinderResultsList = CalculateFinderResultsList();
            FinderResult finderResultAnswer = CalculateFinderResultAnswer(findingType, FinderResultsList);

            return finderResultAnswer;
        }

        private FinderResult CalculateFinderResultAnswer(FindingType findingType, List<FinderResult> FinderResultsList)
        {
            FinderResult finderResultAnswer = new FinderResult();

            if (FinderResultsList.Count > 0)
            {
                finderResultAnswer = FinderResultsList[0];

                foreach (FinderResult finderResult in FinderResultsList)
                {
                    if (findingType.Equals(FindingType.Closest))
                    {
                        finderResultAnswer = CalculateClosestFinderResult(finderResultAnswer, finderResult);
                    }
                    else if (findingType.Equals(FindingType.Furthest))
                    {
                        finderResultAnswer = CalculateFurthestFinderResult(finderResultAnswer, finderResult);
                    }
                }
            }

            return finderResultAnswer;
        }

        private static FinderResult CalculateFurthestFinderResult(FinderResult finderResultAnswer, FinderResult finderResult)
        {
            if (finderResult.TimeBetweenBirthdays > finderResultAnswer.TimeBetweenBirthdays)
            {
                finderResultAnswer = finderResult;
            }
            return finderResultAnswer;
        }

        private FinderResult CalculateClosestFinderResult(FinderResult finderResultAnswer, FinderResult finderResult)
        {
            if (finderResult.TimeBetweenBirthdays < finderResultAnswer.TimeBetweenBirthdays)
            {
                finderResultAnswer = finderResult;
            }

            return finderResultAnswer;
        }

        private List<FinderResult> CalculateFinderResultsList()
        {
            List<FinderResult> FinderResultsList = new List<FinderResult>();

            for (int i = 0; i < _people.Count - 1; i++)
            {
                for (int j = i + 1; j < _people.Count; j++)
                {
                    FinderResult finderResult = CreateFinderResult(i, j);
                    FinderResultsList.Add(finderResult);
                }
            }

            return FinderResultsList;
        }

        private FinderResult CreateFinderResult(int i, int j)
        {
            FinderResult finderResult = new FinderResult();

            if (_people[i].BirthDate < _people[j].BirthDate)
            {
                finderResult.PersonWithEarliestBirthDate = _people[i];
                finderResult.PersonWithMostCurrentBirthDate = _people[j];
            }
            else
            {
                finderResult.PersonWithEarliestBirthDate = _people[j];
                finderResult.PersonWithMostCurrentBirthDate = _people[i];
            }

            finderResult.TimeBetweenBirthdays = finderResult.PersonWithMostCurrentBirthDate.BirthDate - finderResult.PersonWithEarliestBirthDate.BirthDate;

            return finderResult;
        }
    }
}