using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb2
{
    public class SortedPosList
    {
        //En List utav Positions - Private so its only visible in this class
        private List<Position> positionsList = new List<Position>();

        public override string ToString()
        {
            return string.Join(",", positionsList);
        }


        public int Count()
        {
            //returnera antalet positioner vi har i vår lista
            return positionsList.Count;
        }
        public SortedPosList()
        {
        }


        // just to add positions on the correct place
        public void Add(Position pos)
        {


            positionsList.Add(pos);
            positionsList = positionsList.OrderBy(position => position.Length()).ToList();

        }


        // To remove pos from positionslist.
        public bool Remove(Position pos)
        {
            int index = positionsList.FindIndex(position => (position.XValue.Equals(pos.XValue) && position.YValue.Equals(pos.YValue)));

            if (index > -1)
            {
                positionsList.RemoveAt(index);
                return true;
            }
            return false;
        }

        public SortedPosList Clone()
        {
            List<Position> cloned = new List<Position>();
            SortedPosList sortedPos = new SortedPosList();

            foreach (var position in positionsList)
            {
                cloned.Add(position.Clone());
            }

            sortedPos.positionsList = cloned;
            return sortedPos;
        }

        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList circleList = new SortedPosList();
            for (int i = 0; i < positionsList.Count; i++)
            {
                double diameter = Math.Pow(positionsList[i].XValue - centerPos.XValue, 2) + Math.Pow(positionsList[i].YValue - centerPos.YValue, 2);
                double squareRoot = Math.Pow(radius, 2);

                if (diameter < squareRoot)
                {
                    circleList.Add(positionsList[i].Clone());
                }

            }
            return circleList;
        }

        // Overriding operators.
        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList spList = sp1.Clone();
            foreach (Position p in sp2.positionsList)
            {
                spList.Add(p.Clone());
            }
            return spList;
        }


        public Position this[int i]
        {
            get => positionsList[i];
        }


    }
}