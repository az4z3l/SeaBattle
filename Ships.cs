﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattle
{
    class Ships
    {
        public Point[] points;

        public Ships(int numberofdeck) // Creating ship
        {
            points = new Point[numberofdeck];
            foreach(Point point in points)
            {
                point.typeofpoint = 1; // string = "*" - Ship
            }
        }

    }
}
