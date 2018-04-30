﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeaBattle
{
    class AI
    {
        private Random rnd = new Random();
        private int coordinate1;
        private int coordinate2;
        private bool WasDamaged = false;
        private int shipsdecks = 1;

        public void AIShot(Point[,] points, Point[,] aipointsforview)
        {
            while (true)
            {
                if (WasDamaged == false) // CHOOSE NEW TARGET
                {
                    coordinate1 = rnd.Next(0, 9);
                    coordinate2 = rnd.Next(0, 9);
                }

                switch (points[coordinate1, coordinate2].typeofpoint)
                {
                    case 0: // Empty
                        points[coordinate1, coordinate2].typeofpoint = 3; // Empty --> Miss
                        WasDamaged = false;
                        break;

                    case 1: // Ship
                        points[coordinate1, coordinate2].typeofpoint = 2; // Ship --> Damaged
                        WasDamaged = false;

                        Console.WriteLine("Enemy turn.");
                        Thread.Sleep(2000);

                        // Render
                        Console.Clear();
                        Point.SetStringsForPoints(points);
                        Renderer.Render(points);
                        Renderer.Render(aipointsforview);
                        //

                        // CHECKING EMPTY POINTS --> CONTINUE SHOOT or CHOOSE NEW TARGET
                        if (coordinate1 == 0)
                        {
                            if (coordinate2 == 0)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 + 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 + 1].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }

                            else if (coordinate2 == 9)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 + 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }

                            else
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 + 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }
                        }

                        else if (coordinate1 == 9)
                        {
                            if (coordinate2 == 0)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 - 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 + 1].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }

                            else if (coordinate2 == 9)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 - 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }

                            else
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 - 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 + 1].typeofpoint == 0 || points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }
                        }

                        else if (coordinate2 == 0)
                        {
                            if (coordinate1 == 0)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 + 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 + 1].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }

                            else if (coordinate1 == 9)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 + 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 + 1].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }

                            else
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 + 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 + 1].typeofpoint == 0 || points[coordinate1 - 1, coordinate2].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }
                        }

                        else if (coordinate2 == 9)
                        {
                            if (coordinate1 == 0)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 + 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }

                            else if (coordinate1 == 9)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 + 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }

                            else
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 + 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 - 1].typeofpoint == 0 || points[coordinate1 - 1, coordinate2].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }
                        }

                        else if(coordinate1 != 0 && coordinate1 != 9 && coordinate2 != 0 && coordinate2 != 9)
                        {
                            if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 + 1, coordinate2].typeofpoint == 0 || points[coordinate1 - 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 + 1].typeofpoint == 0 || points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                            {
                                continue; // CHOOSE NEW TARGET
                            }
                        }
                        //CHECKING EMPTY POINTS --> CONTINUE SHOOT or CHOOSE NEW TARGET 
                        
                        // CONTINUE SHOOT --> WHERE SHOOT?

                                                                     // ?Ship                                                                                                                                                                                                
                            if(coordinate1 == 9 && coordinate2 == 0) // Ship -- ?Ship
                            {
                                switch (rnd.Next(1, 2))
                                {
                                    case 1:
                                        if (points[coordinate1 + 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 3;
                                        else if(points[coordinate1 + 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 2;                                        
                                            coordinate1 += 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 + 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 + 1].typeofpoint == 1)
                                        {
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 2;
                                            coordinate2 += 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                }
                            }

                           else if(coordinate1 == 9 && coordinate2 == 9)
                            {                                 // ?Ship
                                switch(rnd.Next(1,2)) // ?Ship -- Ship
                                {
                                    case 1:
                                        if (points[coordinate1 + 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 + 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 2;
                                            coordinate1 += 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                        {
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 2;
                                            coordinate2 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;
                                }
                            }

                            else if(coordinate1 == 0 && coordinate2 == 0)
                            {
                                switch (rnd.Next(1, 2)) // Ship -- ?Ship
                                {                       // ?Ship
                                    case 1:
                                        if (points[coordinate1 - 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 - 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 2;
                                            coordinate1 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 + 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 + 1].typeofpoint == 1)
                                        {
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 2;
                                            coordinate1 += 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                }
                            }

                            else if(coordinate1 == 0 && coordinate2 == 9)
                            {                           // ?Ship -- Ship
                                switch (rnd.Next(1, 2)) //         ?Ship
                                {
                                    case 1:
                                        if (points[coordinate1 - 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 - 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 2;
                                            coordinate1 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                        {
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 2;
                                            coordinate2 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                }
                            }

                            else if(coordinate1 == 0 && coordinate2 > 0 && coordinate2 < 9)
                            {
                                switch(rnd.Next(1,3)) // ?Ship -- Ship -- ?Ship
                                {                     //         ?Ship
                                    case 1:
                                        if (points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                        {
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 2;
                                            coordinate1 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 + 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 + 1].typeofpoint == 1)
                                        {
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 2;
                                            coordinate2 += 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 3:
                                        if (points[coordinate1 + 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 + 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 2;
                                            coordinate1 += 1;
                                            WasDamaged = true;
                                        }
                                        break;
                                }
                            }

                            else if(coordinate1 == 9 && coordinate2 > 0 && coordinate2 < 9)
                            {
                                switch(rnd.Next(1,3)) //        ?Ship
                                {                    // ?Ship -- Ship -- ?Ship
                                    case 1:
                                        if (points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                        {
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 2;
                                            coordinate2 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 + 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 + 1].typeofpoint == 1)
                                        {
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 2;
                                            coordinate2 += 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 3:
                                        if (points[coordinate1 - 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 - 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 2;
                                            coordinate1 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                }
                            }

                            else if(coordinate1 > 0 && coordinate1 < 9 && coordinate2 == 0)
                            {                         // ?Ship
                                switch(rnd.Next(1,3)) //  Ship -- ?Ship
                                {                     // ?Ship
                                    case 1:
                                        if (points[coordinate1 + 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 + 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 2;
                                            coordinate1 += 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 + 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 + 1].typeofpoint == 1)
                                        {
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 2;
                                            coordinate2 += 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 3:
                                        if (points[coordinate1 - 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 - 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 2;
                                            coordinate1 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;
                                }
                            }

                            else if(coordinate1 > 0 && coordinate1 < 9 && coordinate2 == 9)
                            {                         //         ?Ship
                                switch(rnd.Next(1,3)) // ?Ship -- Ship
                                {                     //         ?Ship
                                    case 1:
                                        if (points[coordinate1 + 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 + 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 2;
                                            coordinate1 += 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                        {
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 2;
                                            coordinate2 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 3:
                                        if (points[coordinate1 - 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 - 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 2;
                                            coordinate1 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;
                                }
                            }

                            else if(coordinate1 > 0 && coordinate1 < 9 && coordinate2 > 0 && coordinate2 < 9)
                            {                         //         ?Ship
                                switch(rnd.Next(1,4)) // ?Ship -- Ship -- ?Ship
                                {                     //         ?Ship
                                    case 1:
                                        if (points[coordinate1 + 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 + 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 2;
                                            coordinate1 += 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                        {
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 2;
                                            coordinate2 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 3:
                                        if (points[coordinate1 - 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 - 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 2;
                                            coordinate1 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 4:
                                        if (points[coordinate1 + 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 + 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 2;
                                            coordinate1 += 1;
                                            WasDamaged = true;
                                        }
                                        break;
                                    }
                                }

                        // CONTINUE SHOOT --> WHERE SHOOT?

                            break;
                }
                        
                        
                      

                Console.WriteLine("Enemy turn.");
                Thread.Sleep(2000);

                // Render
                Console.Clear();
                Point.SetStringsForPoints(points);
                Renderer.Render(points);
                Renderer.Render(aipointsforview);
                //

                if (WasDamaged == true)
                    continue;

                break;
            
            
            }
        }

        public void AIPreparation(Point[,] points, Ships[] ships)
        {
            while (true)
            {
                if (shipsdecks == 1)
                {
                    for (int index = 0; index < 4;)
                    {
                        coordinate1 = rnd.Next(0, 9);
                        coordinate2 = rnd.Next(0, 9);

                        if (coordinate1 == 0)
                        {
                            if (coordinate2 == 0)
                            {                                                                                                                                                                                                                                         // _______________
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 + 1].typeofpoint == 1) // |Ship -- ?Ship
                                    continue;                                                                                                                                                                                                                         // |?Ship -- ?Ship
                            }

                            else if (coordinate2 == 9)
                            {                                                                                                                                                                                                                                         // _______________
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 - 1].typeofpoint == 1) // ?Ship --  Ship|
                                    continue;                                                                                                                                                                                                                         // ?Ship -- ?Ship|
                            }

                            else
                            {                                                                                                                                                                                                                                                                                                                                                               // _______________________
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 - 1].typeofpoint == 1) // ?Ship -- Ship -- ?Ship
                                    continue;                                                                                                                                                                                                                                                                                                                                               // ?Ship -- ?Ship -- ?Ship
                            }
                        }

                        else if (coordinate1 == 9)
                        {
                            if (coordinate2 == 0)
                            {                                                                                                                                                                                                                                         // |?Ship -- ?Ship
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 + 1].typeofpoint == 1) // |Ship -- ?Ship
                                    continue;                                                                                                                                                                                                                         // ===============
                            }

                            else if (coordinate2 == 9)
                            {                                                                                                                                                                                                                                         // ?Ship -- ?Ship|
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 - 1].typeofpoint == 1) // ?Ship --  Ship|
                                    continue;                                                                                                                                                                                                                         // ===============
                            }

                            else
                            {                                                                                                                                                                                                                                                                                                                                                               // ?Ship -- ?Ship -- ?Ship
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 - 1].typeofpoint == 1) // ?Ship -- Ship -- ?Ship
                                    continue;                                                                                                                                                                                                                                                                                                                                               // =======================
                            }
                        }

                        else if (coordinate2 == 0)
                        {
                            if (coordinate1 == 0)
                            {                                                                                                                                                                                                                                         // _______________
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 + 1].typeofpoint == 1) // |Ship -- ?Ship
                                    continue;                                                                                                                                                                                                                         // |?Ship -- ?Ship
                            }

                            else if (coordinate1 == 9)
                            {                                                                                                                                                                                                                                         // |?Ship -- ?Ship
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 + 1].typeofpoint == 1) // |Ship --  ?Ship
                                    continue;                                                                                                                                                                                                                         // ===============
                            }

                            else
                            {                                                                                                                                                                                                                                                                                                                                                               // |?Ship -- ?Ship
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 + 1].typeofpoint == 1) // | Ship -- ?Ship
                                    continue;                                                                                                                                                                                                                                                                                                                                               // |?Ship -- ?Ship
                            }
                        }

                        else if(coordinate2 == 9)
                        {
                            if (coordinate1 == 0)
                            {                                                                                                                                                                                                                                         // _______________
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 - 1].typeofpoint == 1) // ?Ship --  Ship|
                                    continue;                                                                                                                                                                                                                         // ?Ship -- ?Ship|
                            }

                            else if (coordinate1 == 9)
                            {                                                                                                                                                                                                                                         // ?Ship -- ?Ship|
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 - 1].typeofpoint == 1) // ?Ship --  Ship|
                                    continue;                                                                                                                                                                                                                         // ===============
                            }

                            else
                            {                                                                                                                                                                                                                                                                                                                                                               // ?Ship -- ?Ship|
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 - 1].typeofpoint == 1) // ?SHip --  Ship|
                                    continue;                                                                                                                                                                                                                                                                                                                                               // ?Ship -- ?Ship|
                            }
                        }

                        else
                        {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  // ?Ship -- ?Ship -- ?Ship 
                            if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 - 1].typeofpoint == 1) // ?Ship --  Ship -- ?Ship
                            {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              // ?Ship -- ?Ship -- ?Ship
                                continue;
                            }
                        }

                        points[coordinate1, coordinate2].typeofpoint = 1; // Empty --> Ship
                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]); // typeofpoint = typeofpoint
                        index++;
                    }
                    shipsdecks = 2;
                }

                else if (shipsdecks == 2)
                {
                    for (int index = 4; index < 7;)
                    {
                        coordinate1 = rnd.Next(0, 9);
                        coordinate2 = rnd.Next(0, 9);

                        if (coordinate1 == 0)
                        {
                            if (coordinate2 == 0)
                            {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  // _______________________________________
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 + 2, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 + 2].typeofpoint == 1 || points[coordinate1 + 2, coordinate2 + 2].typeofpoint == 1 || points[coordinate1 + 2, coordinate2 + 1].typeofpoint == 1) // |Ship(0,0)  -- ?Ship(0,1) -- ?Ship(0,2)
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               // |?Ship(1,0) -- ?Ship(1,1) -- ?Ship(1,2)
                                    continue;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  // |?Ship(2,0) -- ?Ship(2,1) -- ?SHip(2,2)
                            }

                            else if (coordinate2 == 9)
                            {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  // _______________________________________
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 + 2, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 - 2].typeofpoint == 1 || points[coordinate1 + 2, coordinate2 - 2].typeofpoint == 1 || points[coordinate1 + 2, coordinate2 - 1].typeofpoint == 1) // ?Ship(0,7)  -- ?Ship(0,8) -- Ship(0,9)|
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               // ?Ship(1,7) -- ?Ship(1,8) -- ?Ship(1,9)|
                                    continue;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  // ?Ship(2,7) -- ?Ship(2,8) -- ?SHip(2,9)|
                            }

                            else
                            {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              // ____________________________________________________________________________________
                                if (points[coordinate1, coordinate2 - 2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1, coordinate2 + 2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 - 2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 + 2].typeofpoint == 1 || points[coordinate1 + 2, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 + 2, coordinate2].typeofpoint == 1 || points[coordinate1 + 2, coordinate2 + 1].typeofpoint == 1) // ?Ship(x,x-2)   -- ?Ship(x,x-1)   --  Ship(x,x)   -- ?Ship(x,x+1)   -- ?Ship(x,x+2)
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           // ?Ship(x+1,x-2) -- ?Ship(x+1,x-1) -- ?Ship(x+1,x) -- ?Ship(x+1,x+1) -- ?Ship(x+1,x+2)
                                    continue;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              //                   ?Ship(x+2,x-1) -- ?Ship(x+2,x) -- ?Ship(x+2,x+1)
                            }
                        }

                        else if (coordinate1 == 9)
                        {
                            if (coordinate2 == 0)
                            {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 - 2, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 + 2].typeofpoint == 1 || points[coordinate1 - 2, coordinate2 + 2].typeofpoint == 1 || points[coordinate1 - 2, coordinate2 + 1].typeofpoint == 1) // |?Ship(7,0) -- ?Ship(7,1) -- ?Ship(7,2)
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               // |?Ship(8,0) -- ?Ship(8,1) -- ?Ship(8,2)
                                    continue;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  // | Ship(9,0) -- ?Ship(9,1) -- ?SHip(9,2)
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               // =======================================
                            }

                            else if (coordinate2 == 9)
                            {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 - 2, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 - 2].typeofpoint == 1 || points[coordinate1 - 2, coordinate2 - 2].typeofpoint == 1 || points[coordinate1 - 2, coordinate2 - 1].typeofpoint == 1) // ?Ship(7,7) -- ?Ship(7,8) -- ?Ship(7,9)|
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               // ?Ship(8,7) -- ?Ship(8,8) -- ?Ship(8,9)|
                                    continue;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  // ?Ship(9,7) -- ?Ship(9,8) -- ?Ship(9,9)|
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               // =======================================
                            }

                            else
                            {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
                                if (points[coordinate1 - 2, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 - 2, coordinate2].typeofpoint == 1 || points[coordinate1 - 2, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 - 2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 + 2].typeofpoint == 1 || points[coordinate1, coordinate2 - 2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1, coordinate2 + 2].typeofpoint == 1) //                   ?Ship(x-2,x-1) --  Ship(x-2,x) -- ?Ship(x-2,x+1)
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           // ?Ship(x-1,x-2) -- ?Ship(x-1,x-1) -- ?Ship(x-1,x) -- ?Ship(x-1,x+1) -- ?Ship(x-1,x+2)
                                    continue;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              // ?Ship(x,x-2)   -- ?Ship(x,x-1)   --  Ship(x,x)   -- ?Ship(x,x+1)   -- ?Ship(x,x+2)
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           // ====================================================================================
                            }
                        }

                        else if (coordinate2 == 0)
                        {
                            if (coordinate1 == 0)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 + 1].typeofpoint == 1)
                                    continue;
                            }

                            else if (coordinate1 == 9)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 + 1].typeofpoint == 1)
                                    continue;
                            }

                            else
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 + 1].typeofpoint == 1)
                                    continue;
                            }
                        }

                        else if (coordinate2 == 9)
                        {
                            if (coordinate1 == 0)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 - 1].typeofpoint == 1)
                                    continue;
                            }

                            else if (coordinate1 == 9)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 - 1].typeofpoint == 1)
                                    continue;
                            }

                            else
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 - 1].typeofpoint == 1)
                                    continue;
                            }
                        }

                        else
                        {
                            if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 + 1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2 - 1].typeofpoint == 1)
                            {
                                continue;
                            }
                        }

                                              // ----        
                        if (coordinate1 == 0) // Ship   OR  Ship -- Ship
                        {                     // Ship
                            switch (rnd.Next(1, 2))
                            {
                                case 1:
                                    points[coordinate1, coordinate2].typeofpoint = 1;
                                    points[coordinate1 + 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);
                                    RefOfShipsAndPoints(ref points[coordinate1 + 1, coordinate2], ref ships[index].points[1]);
                                    break;

                                case 2:
                                    if (coordinate2 == 9)
                                    {
                                        points[coordinate1, coordinate2].typeofpoint = 1;
                                        points[coordinate1 + 1, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);
                                        RefOfShipsAndPoints(ref points[coordinate1 + 1, coordinate2], ref ships[index].points[1]);
                                    }
                                    else
                                    {
                                        points[coordinate1, coordinate2].typeofpoint = 1;
                                        points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                    }
                                    break;
                            }
                        }
                                                   // Ship
                        else if (coordinate1 == 9) // Ship   OR Ship -- Ships
                        {                          // ----
                            switch (rnd.Next(1, 2))
                            {
                                case 1:
                                    points[coordinate1, coordinate2].typeofpoint = 1;
                                    points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);
                                    RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                    break;

                                case 2:
                                    if (coordinate2 == 9)
                                    {
                                        points[coordinate1, coordinate2].typeofpoint = 1;
                                        points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);
                                        RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                    }
                                    else
                                    {
                                        points[coordinate1, coordinate2].typeofpoint = 1;
                                        points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                    }
                                    break;
                            }
                        }
                                                   // | Ship
                        else if (coordinate2 == 0) // | Ship   OR | Ship -- Ship
                        {
                            switch (rnd.Next(1, 2))
                            {
                                case 1:
                                    points[coordinate1, coordinate2].typeofpoint = 1;
                                    points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                    break;

                                case 2:
                                    if (coordinate1 == 9)
                                    {
                                        points[coordinate1, coordinate2].typeofpoint = 1;
                                        points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                    }

                                    else
                                    {
                                        points[coordinate1, coordinate2].typeofpoint = 1;
                                        points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);
                                        RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                    }
                                    break;
                            }
                        }

                                                   //  Ship |
                        else if (coordinate2 == 9) //  Ship |  OR  Ship -- Ship |
                        {
                            switch (rnd.Next(1, 2))
                            {
                                case 1:
                                    points[coordinate1, coordinate2].typeofpoint = 1;
                                    points[coordinate1, coordinate2 - 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 1], ref ships[index].points[1]);
                                    break;

                                case 2:
                                    if (coordinate1 == 9)
                                    {
                                        points[coordinate1, coordinate2].typeofpoint = 1;
                                        points[coordinate1, coordinate2 - 1].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 1], ref ships[index].points[1]);
                                    }

                                    else
                                    {
                                        points[coordinate1, coordinate2].typeofpoint = 1;
                                        points[coordinate1 + 1, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);
                                        RefOfShipsAndPoints(ref points[coordinate1 + 1, coordinate2], ref ships[index].points[1]);
                                    }
                                    break;
                            }
                        }

                        else
                        {
                            points[coordinate1, coordinate2].typeofpoint = 1;
                            RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);
                            switch (rnd.Next(1, 4))
                            {
                                case 1:
                                    points[coordinate1 + 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 + 1, coordinate2], ref ships[index].points[1]);
                                    break;

                                case 2:
                                    points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                    break;

                                case 3:
                                    points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                    break;

                                case 4:
                                    points[coordinate1, coordinate2 - 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 1], ref ships[index].points[1]);
                                    break;

                            }
                        }

                        index++;
                    }
                    shipsdecks = 3;
                }

                else if (shipsdecks == 3)
                {
                    for (int index = 7; index < 9;)
                    {
                        coordinate1 = rnd.Next(0, 9);
                        coordinate2 = rnd.Next(0, 9);

                        if (coordinate1 == 0)
                        {
                            if (coordinate2 == 0)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1)
                                    continue;
                            }

                            else if (coordinate2 == 9)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                    continue;
                            }

                            else
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                    continue;
                            }
                        }

                        else if (coordinate1 == 9)
                        {
                            if (coordinate2 == 0)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1)
                                    continue;
                            }

                            else if (coordinate2 == 9)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                    continue;
                            }

                            else
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                    continue;
                            }
                        }

                        else if (coordinate2 == 0)
                        {
                            if (coordinate1 == 0)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1)
                                    continue;
                            }

                            else if (coordinate1 == 9)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1)
                                    continue;
                            }

                            else
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1)
                                    continue;
                            }
                        }

                        else if (coordinate2 == 9)
                        {
                            if (coordinate1 == 0)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                    continue;
                            }

                            else if (coordinate1 == 9)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                    continue;
                            }

                            else
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1)
                                    continue;
                            }
                        }

                        else
                        {
                            if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                            {
                                continue;
                            }
                        }

                        // ---- 
                        if (coordinate1 == 0) // Ship
                        {                 // Ship OR Ship -- Ship -- Ship
                                          // Ship
                            points[coordinate1, coordinate2].typeofpoint = 1;
                            RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                            switch (rnd.Next(1, 2))
                            {
                                case 1:
                                    points[coordinate1 + 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 + 1, coordinate2], ref ships[index].points[1]);
                                    points[coordinate1 + 2, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 + 2, coordinate2], ref ships[index].points[2]);
                                    break;

                                case 2:
                                    if (coordinate2 == 7 || coordinate2 == 8 || coordinate2 == 9)
                                    {
                                        points[coordinate1 + 1, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1 + 1, coordinate2], ref ships[index].points[1]);
                                        points[coordinate1 + 2, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1 + 2, coordinate2], ref ships[index].points[2]);
                                        break;
                                    }

                                    else
                                    {
                                        points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                        points[coordinate1, coordinate2 + 2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 2], ref ships[index].points[2]);
                                    }
                                    break;
                            }
                        }
                        // Ship
                        if (coordinate1 == 9) // Ship  OR  Ship -- Ship -- SHip 
                        {                     // Ship
                                              // ----
                            points[coordinate1, coordinate2].typeofpoint = 1;
                            RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                            switch (rnd.Next(1, 2))
                            {
                                case 1:
                                    points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                    points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                    break;

                                case 2:
                                    if (coordinate2 == 7 || coordinate2 == 8 || coordinate2 == 9)
                                    {
                                        points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                        points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                        break;
                                    }

                                    else
                                    {
                                        points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                        points[coordinate1, coordinate2 + 2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 2], ref ships[index].points[2]);
                                    }
                                    break;
                            }
                        }
                        // | Ship
                        if (coordinate2 == 0) // | Ship  OR  Ship -- SHip -- Ship
                        {                     // | Ship

                            points[coordinate1, coordinate2].typeofpoint = 1;
                            RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                            switch (rnd.Next(1, 2))
                            {
                                case 1:
                                    if (coordinate1 == 7 || coordinate1 == 8 || coordinate1 == 9)
                                    {
                                        points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                        points[coordinate1, coordinate2 + 2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 2], ref ships[index].points[2]);
                                        break;
                                    }

                                    else
                                    {
                                        points[coordinate1 + 1, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                        points[coordinate1 + 2, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                    }
                                    break;

                                case 2:
                                    points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                    points[coordinate1, coordinate2 + 2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 2], ref ships[index].points[2]);
                                    break;
                            }
                        }
                        // Ship |
                        if (coordinate2 == 9) // Ship |  OR Ship -- Ship -- Ship
                                              // Ship |
                        {
                            points[coordinate1, coordinate2].typeofpoint = 1;
                            RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                            switch (rnd.Next(1, 2))
                            {
                                case 1:
                                    if (coordinate1 == 7 || coordinate1 == 8 || coordinate1 == 9)
                                    {
                                        points[coordinate1, coordinate2 - 1].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 1], ref ships[index].points[1]);
                                        points[coordinate1, coordinate2 - 2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 2], ref ships[index].points[2]);
                                    }

                                    else
                                    {
                                        points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                        points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                    }
                                    break;

                                case 2:
                                    points[coordinate1, coordinate2 - 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 1], ref ships[index].points[1]);
                                    points[coordinate1, coordinate2 - 2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 2], ref ships[index].points[2]);
                                    break;
                            }
                        }

                        else if (coordinate1 > 1 && coordinate1 < 8 && coordinate2 > 1 && coordinate2 < 8)
                        {
                            points[coordinate1, coordinate2].typeofpoint = 1;
                            RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                            switch (rnd.Next(1, 4))
                            {
                                case 1:
                                    points[coordinate1 + 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 + 1, coordinate2], ref ships[index].points[1]);
                                    points[coordinate1 + 2, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 + 2, coordinate2], ref ships[index].points[2]);
                                    break;

                                case 2:
                                    points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                    points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                    break;

                                case 3:
                                    points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                    points[coordinate1, coordinate2 + 2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 2], ref ships[index].points[2]);
                                    break;

                                case 4:
                                    points[coordinate1, coordinate2 - 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 1], ref ships[index].points[1]);
                                    points[coordinate1, coordinate2 - 2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 2], ref ships[index].points[2]);
                                    break;
                            }
                        }

                        else if (coordinate1 == 1 && coordinate2 > 0 && coordinate2 < 9)
                        {
                            points[coordinate1, coordinate2].typeofpoint = 1;
                            RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                            switch (rnd.Next(1, 2))
                            {
                                case 1:
                                    points[coordinate1 + 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                    points[coordinate1 + 2, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 + 2, coordinate2], ref ships[index].points[2]);
                                    break;

                                case 2:
                                    if (coordinate2 == 8)
                                    {
                                        points[coordinate1 + 1, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                        points[coordinate1 + 2, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2 + 1], ref ships[index].points[2]);
                                    }

                                    else
                                    {
                                        points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                        points[coordinate1, coordinate2 + 2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 2], ref ships[index].points[2]);
                                    }
                                    break;
                            }

                        }

                        else if (coordinate1 == 8 && coordinate2 > 0 && coordinate2 < 9)
                        {
                            points[coordinate1, coordinate2].typeofpoint = 1;
                            RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                            switch (rnd.Next(1, 2))
                            {
                                case 1:
                                    points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                    points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                    break;

                                case 2:
                                    if (coordinate2 == 8)
                                    {
                                        points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1 + 1, coordinate2], ref ships[index].points[1]);
                                        points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1 + 1, coordinate2], ref ships[index].points[2]);
                                    }

                                    else
                                    {
                                        points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                        points[coordinate1, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[2]);
                                    }
                                    break;
                            }
                        }

                        else if (coordinate2 == 1 && coordinate1 > 0 && coordinate1 < 9)
                        {
                            points[coordinate1, coordinate2].typeofpoint = 1;
                            RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                            switch (rnd.Next(1, 2))
                            {
                                case 1:
                                    if (coordinate1 == 8)
                                    {
                                        points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                        points[coordinate1, coordinate2 + 2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 2], ref ships[index].points[2]);
                                    }

                                    else
                                    {
                                        points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                        points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                    }

                                    break;

                                case 2:
                                    points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                    points[coordinate1, coordinate2 + 2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 2], ref ships[index].points[2]);
                                    break;
                            }
                        }

                        else if (coordinate2 == 9 && coordinate1 > 0 && coordinate1 < 9)
                        {
                            points[coordinate1, coordinate2].typeofpoint = 1;
                            RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                            switch (rnd.Next(1, 2))
                            {
                                case 1:
                                    if (coordinate1 == 8)
                                    {
                                        points[coordinate1, coordinate2 - 1].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 1], ref ships[index].points[1]);
                                        points[coordinate1, coordinate2 - 2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 2], ref ships[index].points[2]);
                                    }

                                    else
                                    {
                                        points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                        points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                        RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                    }

                                    break;

                                case 2:
                                    points[coordinate1, coordinate2 - 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 1], ref ships[index].points[1]);
                                    points[coordinate1, coordinate2 - 2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 2], ref ships[index].points[2]);
                                    break;
                            }
                        }
                        index++;
                    }

                    shipsdecks = 4;
                }

                else if (shipsdecks == 4)
                {
                    int index = 9;

                    coordinate1 = rnd.Next(0, 9);
                    coordinate2 = rnd.Next(0, 9);

                    if (coordinate1 == 0)
                    {
                        if (coordinate2 == 0)
                        {
                            if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1)
                                continue;
                        }

                        else if (coordinate2 == 9)
                        {
                            if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                continue;
                        }

                        else
                        {
                            if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                continue;
                        }
                    }

                    else if (coordinate1 == 9)
                    {
                        if (coordinate2 == 0)
                        {
                            if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1)
                                continue;
                        }

                        else if (coordinate2 == 9)
                        {
                            if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                continue;
                        }

                        else
                        {
                            if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                continue;
                        }
                    }

                    else if (coordinate2 == 0)
                    {
                        if (coordinate1 == 0)
                        {
                            if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1)
                                continue;
                        }

                        else if (coordinate1 == 9)
                        {
                            if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1)
                                continue;
                        }

                        else
                        {
                            if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1)
                                continue;
                        }
                    }

                    else if (coordinate2 == 9)
                    {
                        if (coordinate1 == 0)
                        {
                            if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                continue;
                        }

                        else if (coordinate1 == 9)
                        {
                            if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                continue;
                        }

                        else
                        {
                            if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1)
                                continue;
                        }
                    }

                    else
                    {
                        if (points[coordinate1, coordinate2].typeofpoint == 1 || points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                        {
                            continue;
                        }
                    }

                    if (coordinate1 == 1)
                    {
                        points[coordinate1, coordinate2].typeofpoint = 1;
                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                        switch (rnd.Next(1, 2))
                        {
                            case 1:
                                points[coordinate1 + 1, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 + 1, coordinate2], ref ships[index].points[1]);
                                points[coordinate1 + 2, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 + 2, coordinate2], ref ships[index].points[2]);
                                points[coordinate1 + 3, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 + 3, coordinate2], ref ships[index].points[3]);
                                break;

                            case 2:
                                if (coordinate2 == 7 || coordinate2 == 8 || coordinate2 == 9)
                                {
                                    points[coordinate1 + 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 + 1, coordinate2], ref ships[index].points[1]);
                                    points[coordinate1 + 2, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 + 2, coordinate2], ref ships[index].points[2]);
                                    points[coordinate1 + 3, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 + 3, coordinate2], ref ships[index].points[3]);
                                }

                                else
                                {
                                    points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                    points[coordinate1, coordinate2 + 2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 2], ref ships[index].points[2]);
                                    points[coordinate1, coordinate2 + 3].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 3], ref ships[index].points[3]);
                                }
                                break;
                        }
                    }

                    else if (coordinate1 == 9)
                    {
                        points[coordinate1, coordinate2].typeofpoint = 1;
                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                        switch (rnd.Next(1, 2))
                        {
                            case 1:
                                points[coordinate1 + 1, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 + 1, coordinate2], ref ships[index].points[1]);
                                points[coordinate1 + 2, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 + 2, coordinate2], ref ships[index].points[2]);
                                points[coordinate1 + 3, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 + 3, coordinate2], ref ships[index].points[3]);
                                break;

                            case 2:
                                if (coordinate2 == 7 || coordinate2 == 8 || coordinate2 == 9)
                                {
                                    points[coordinate1 + 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 + 1, coordinate2], ref ships[index].points[1]);
                                    points[coordinate1 + 2, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 + 2, coordinate2], ref ships[index].points[2]);
                                    points[coordinate1 + 3, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 + 3, coordinate2], ref ships[index].points[3]);
                                }

                                else
                                {
                                    points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                    points[coordinate1, coordinate2 + 2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 2], ref ships[index].points[2]);
                                    points[coordinate1, coordinate2 + 3].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 3], ref ships[index].points[3]);
                                }
                                break;
                        }
                    }

                    else if (coordinate2 == 0)
                    {
                        points[coordinate1, coordinate2].typeofpoint = 1;
                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                        switch (rnd.Next(1, 2))
                        {
                            case 1:
                                points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                points[coordinate1, coordinate2 + 2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 2], ref ships[index].points[2]);
                                points[coordinate1, coordinate2 + 3].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 3], ref ships[index].points[3]);
                                break;

                            case 2:
                                if (coordinate1 == 7 || coordinate1 == 8 || coordinate1 == 9)
                                {
                                    points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                    points[coordinate1, coordinate2 + 2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 2], ref ships[index].points[2]);
                                    points[coordinate1, coordinate2 + 3].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 3], ref ships[index].points[3]);
                                }

                                else
                                {
                                    points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                    points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                    points[coordinate1 - 3, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 3, coordinate2], ref ships[index].points[3]);
                                }
                                break;
                        }
                    }

                    else if (coordinate2 == 9)
                    {
                        points[coordinate1, coordinate2].typeofpoint = 1;
                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                        switch (rnd.Next(1, 2))
                        {
                            case 1:
                                points[coordinate1, coordinate2 - 1].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 1], ref ships[index].points[1]);
                                points[coordinate1, coordinate2 - 2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 2], ref ships[index].points[2]);
                                points[coordinate1, coordinate2 - 3].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 3], ref ships[index].points[3]);
                                break;

                            case 2:
                                if (coordinate1 == 7 || coordinate1 == 8 || coordinate1 == 9)
                                {
                                    points[coordinate1, coordinate2 - 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 1], ref ships[index].points[1]);
                                    points[coordinate1, coordinate2 - 2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 2], ref ships[index].points[2]);
                                    points[coordinate1, coordinate2 - 3].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 3], ref ships[index].points[3]);
                                }

                                else
                                {
                                    points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                    points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                    points[coordinate1 - 3, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 3, coordinate2], ref ships[index].points[3]);
                                }
                                break;
                        }
                    }

                    else if (coordinate1 > 2 && coordinate1 < 7 && coordinate2 > 2 && coordinate2 < 7)
                    {
                        points[coordinate1, coordinate2].typeofpoint = 1;
                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                        switch (rnd.Next(1, 4))
                        {
                            case 1:
                                points[coordinate1, coordinate2 - 1].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 1], ref ships[index].points[1]);
                                points[coordinate1, coordinate2 - 2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 2], ref ships[index].points[2]);
                                points[coordinate1, coordinate2 - 3].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 3], ref ships[index].points[3]);
                                break;

                            case 2:
                                points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                points[coordinate1, coordinate2 + 2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 2], ref ships[index].points[2]);
                                points[coordinate1, coordinate2 + 3].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 3], ref ships[index].points[3]);
                                break;

                            case 3:
                                points[coordinate1 + 1, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 + 1, coordinate2], ref ships[index].points[1]);
                                points[coordinate1 + 2, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 + 2, coordinate2], ref ships[index].points[2]);
                                points[coordinate1 + 3, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 + 3, coordinate2], ref ships[index].points[3]);
                                break;

                            case 4:
                                points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                points[coordinate1 - 3, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 - 3, coordinate2], ref ships[index].points[3]);
                                break;
                        }
                    }

                    else if (coordinate1 == 1)
                    {
                        points[coordinate1, coordinate2].typeofpoint = 1;
                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                        switch (rnd.Next(1, 2))
                        {
                            case 1:
                                points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                points[coordinate1 - 3, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 - 3, coordinate2], ref ships[index].points[3]);
                                break;

                            case 2:
                                if (coordinate2 == 7 || coordinate2 == 8 || coordinate2 == 9)
                                {
                                    points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                    points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                    points[coordinate1 - 3, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 3, coordinate2], ref ships[index].points[3]);
                                }

                                else
                                {
                                    points[coordinate1, coordinate2 - 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 1], ref ships[index].points[1]);
                                    points[coordinate1, coordinate2 - 2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 2], ref ships[index].points[2]);
                                    points[coordinate1, coordinate2 - 3].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 3], ref ships[index].points[3]);
                                }
                                break;
                        }
                    }

                    else if (coordinate1 == 2)
                    {
                        points[coordinate1, coordinate2].typeofpoint = 1;
                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                        switch (rnd.Next(1, 2))
                        {
                            case 1:
                                points[coordinate1 + 1, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 + 1, coordinate2], ref ships[index].points[1]);
                                points[coordinate1 + 2, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 + 2, coordinate2], ref ships[index].points[2]);
                                points[coordinate1 + 3, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 + 3, coordinate2], ref ships[index].points[3]);
                                break;

                            case 2:
                                if (coordinate2 == 7 || coordinate2 == 8 || coordinate2 == 9)
                                {
                                    points[coordinate1 + 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 + 1, coordinate2], ref ships[index].points[1]);
                                    points[coordinate1 + 2, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 + 2, coordinate2], ref ships[index].points[2]);
                                    points[coordinate1 + 3, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 + 3, coordinate2], ref ships[index].points[3]);
                                }

                                else
                                {
                                    points[coordinate1, coordinate2 - 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 1], ref ships[index].points[1]);
                                    points[coordinate1, coordinate2 - 2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 2], ref ships[index].points[2]);
                                    points[coordinate1, coordinate2 - 3].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 3], ref ships[index].points[3]);
                                }
                                break;
                        }
                    }

                    else if (coordinate1 == 7)
                    {
                        points[coordinate1, coordinate2].typeofpoint = 1;
                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                        switch (rnd.Next(1, 2))
                        {
                            case 1:
                                points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                points[coordinate1 - 3, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 - 3, coordinate2], ref ships[index].points[3]);
                                break;

                            case 2:
                                if (coordinate2 == 7 || coordinate2 == 8 || coordinate2 == 9)
                                {
                                    points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                    points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                    points[coordinate1 - 3, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 3, coordinate2], ref ships[index].points[3]);
                                }

                                else
                                {
                                    points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                    points[coordinate1, coordinate2 + 2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 2], ref ships[index].points[2]);
                                    points[coordinate1, coordinate2 + 3].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 3], ref ships[index].points[3]);
                                }
                                break;
                        }
                    }

                    else if (coordinate1 == 8)
                    {
                        points[coordinate1, coordinate2].typeofpoint = 1;
                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                        switch (rnd.Next(1, 2))
                        {
                            case 1:
                                points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                points[coordinate1 - 3, coordinate2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1 - 3, coordinate2], ref ships[index].points[3]);
                                break;

                            case 2:
                                if (coordinate2 == 7 || coordinate2 == 8 || coordinate2 == 9)
                                {
                                    points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                    points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                    points[coordinate1 - 3, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 3, coordinate2], ref ships[index].points[3]);
                                }

                                else
                                {
                                    points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                    points[coordinate1, coordinate2 + 2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 2], ref ships[index].points[2]);
                                    points[coordinate1, coordinate2 + 3].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 3], ref ships[index].points[3]);
                                }
                                break;
                        }
                    }

                    else if (coordinate2 == 1)
                    {
                        points[coordinate1, coordinate2].typeofpoint = 1;
                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                        switch (rnd.Next(1, 2))
                        {
                            case 1:
                                points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                points[coordinate1, coordinate2 + 2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 2], ref ships[index].points[2]);
                                points[coordinate1, coordinate2 + 3].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 3], ref ships[index].points[3]);
                                break;

                            case 2:
                                if (coordinate1 == 7 || coordinate1 == 8 || coordinate1 == 9)
                                {
                                    points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                    points[coordinate1, coordinate2 + 2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 2], ref ships[index].points[2]);
                                    points[coordinate1, coordinate2 + 3].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 3], ref ships[index].points[3]);
                                }

                                else
                                {
                                    points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                    points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                    points[coordinate1 - 3, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 3, coordinate2], ref ships[index].points[3]);
                                }
                                break;
                        }
                    }

                    else if (coordinate2 == 2)
                    {
                        points[coordinate1, coordinate2].typeofpoint = 1;
                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                        switch (rnd.Next(1, 2))
                        {
                            case 1:
                                points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                points[coordinate1, coordinate2 + 2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 2], ref ships[index].points[2]);
                                points[coordinate1, coordinate2 + 3].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 3], ref ships[index].points[3]);
                                break;

                            case 2:
                                if (coordinate1 == 7 || coordinate1 == 8 || coordinate1 == 9)
                                {
                                    points[coordinate1, coordinate2 + 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 1], ref ships[index].points[1]);
                                    points[coordinate1, coordinate2 + 2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 2], ref ships[index].points[2]);
                                    points[coordinate1, coordinate2 + 3].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 + 3], ref ships[index].points[3]);
                                }

                                else
                                {
                                    points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                    points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                    points[coordinate1 - 3, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 3, coordinate2], ref ships[index].points[3]);
                                }
                                break;
                        }
                    }

                    else if (coordinate2 == 7)
                    {
                        points[coordinate1, coordinate2].typeofpoint = 1;
                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                        switch (rnd.Next(1, 2))
                        {
                            case 1:
                                points[coordinate1, coordinate2 - 1].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 1], ref ships[index].points[1]);
                                points[coordinate1, coordinate2 - 2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 2], ref ships[index].points[2]);
                                points[coordinate1, coordinate2 - 3].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 3], ref ships[index].points[3]);
                                break;

                            case 2:
                                if (coordinate1 == 7 || coordinate1 == 8 || coordinate1 == 9)
                                {
                                    points[coordinate1, coordinate2 - 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 1], ref ships[index].points[1]);
                                    points[coordinate1, coordinate2 - 2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 2], ref ships[index].points[2]);
                                    points[coordinate1, coordinate2 - 3].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 3], ref ships[index].points[3]);
                                }

                                else
                                {
                                    points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                    points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                    points[coordinate1 - 3, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 3, coordinate2], ref ships[index].points[3]);
                                }
                                break;
                        }
                    }

                    else if (coordinate2 == 8)
                    {
                        points[coordinate1, coordinate2].typeofpoint = 1;
                        RefOfShipsAndPoints(ref points[coordinate1, coordinate2], ref ships[index].points[0]);

                        switch (rnd.Next(1, 2))
                        {
                            case 1:
                                points[coordinate1, coordinate2 - 1].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 1], ref ships[index].points[1]);
                                points[coordinate1, coordinate2 - 2].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 2], ref ships[index].points[2]);
                                points[coordinate1, coordinate2 - 3].typeofpoint = 1;
                                RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 3], ref ships[index].points[3]);
                                break;

                            case 2:
                                if (coordinate1 == 7 || coordinate1 == 8 || coordinate1 == 9)
                                {
                                    points[coordinate1, coordinate2 - 1].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 1], ref ships[index].points[1]);
                                    points[coordinate1, coordinate2 - 2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 2], ref ships[index].points[2]);
                                    points[coordinate1, coordinate2 - 3].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1, coordinate2 - 3], ref ships[index].points[3]);
                                }

                                else
                                {
                                    points[coordinate1 - 1, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 1, coordinate2], ref ships[index].points[1]);
                                    points[coordinate1 - 2, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 2, coordinate2], ref ships[index].points[2]);
                                    points[coordinate1 - 3, coordinate2].typeofpoint = 1;
                                    RefOfShipsAndPoints(ref points[coordinate1 - 3, coordinate2], ref ships[index].points[3]);
                                }
                                break;
                        }
                    }
                    break;
                }
            }
        }

        private void RefOfShipsAndPoints(ref Point point1, ref Point point2)
        {
            point1 = point2;
        }
    }
}

