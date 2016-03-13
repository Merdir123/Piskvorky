using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piskvorky
{
    class AI
    {
        //PoleForm poleForm = new PoleForm();
        bool vyplneno = false;
        Random random = new Random();
        int randomX;
        int randomY;
        int max = 0;
        int x = 0;
        int y = 0;
        int hrac = 0;
        int nahoda;
    
        
        int[,] hodnoty = new int[PoleForm.velikostPole, PoleForm.velikostPole];

        //string[,] znaky;
        public AI()
        {

        }
        public void Lehky(string[,] znaky, ref int x, ref int y)
        {
            vyplneno = false;
            while (vyplneno == false)
            {

                randomX = random.Next(0, PoleForm.velikostPole);
                randomY = random.Next(0, PoleForm.velikostPole);
                if (znaky[randomX, randomY] == "")
                {
                    x = randomX;
                    y = randomY;
                    vyplneno = true;
                }

            }
        }
        public void Stredni(string[,] znaky, int hrac, ref int x, ref int y)
        {
            max = 0;
            this.hrac = hrac;
            for (int i = 0; i < PoleForm.velikostPole; i++)
            {
                for (int j = 0; j < PoleForm.velikostPole; j++)
                {
                    if (znaky[i ,j] == "")
                    {
                        //metoda Ohodnoceni
                        Ohodnoceni(znaky, i, j);
                        //vybrání nejlepšího políčka
                        
                        //ref x, y
                    }
                }
            }                   
        }
        public void Ohodnoceni(string[,] znaky, int x, int y)
        {
            //projede pole a každému políčku přiřadí hodnotu podle toho kdo je na tahu
            switch (hrac)
            {
                case 0:
                    hodnoty[x, y] = 0;
                    
                    if (x <= PoleForm.velikostPole - 5)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (znaky[x + i, y] == "O")
                            {
                                hodnoty[x, y] += 1;
                            }
                        }
                    }

                    if (x >= 5)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (znaky[x - i, y] == "O")
                            {
                                hodnoty[x, y] += 1;
                            }
                        }
                    }

                    if (y >= 5)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (znaky[x, y - i] == "O")
                            {
                                hodnoty[x, y] += 1;
                            }
                        }
                    }

                    if (y <= PoleForm.velikostPole - 5)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (znaky[x, y + i] == "O")
                            {
                                hodnoty[x, y] += 1;
                            }
                        }
                    }

                    if (x <= PoleForm.velikostPole - 5)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (znaky[x + i, y] == "X")
                            {
                                hodnoty[x, y] += 2;
                            }
                        }
                    }

                    if (x >= 5)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (znaky[x - i, y] == "X")
                            {
                                hodnoty[x, y] += 2;
                            }
                        }
                    }

                    if (y >= 5)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (znaky[x, y - i] == "X")
                            {
                                hodnoty[x, y] += 2;
                            }
                        }
                    }

                    if (y <= PoleForm.velikostPole - 5)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (znaky[x, y + i] == "X")
                            {
                                hodnoty[x, y] += 2;
                            }
                        }
                    }

                    if (x <= PoleForm.velikostPole - 5 & y <= PoleForm.velikostPole - 5)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (znaky[x + i, y + 1] == "X")
                            {
                                hodnoty[x, y] += 2;
                            }
                        }
                    }

                    if (x >= 5 & y >= 5)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (znaky[x - i, y - 1] == "X")
                            {
                                hodnoty[x, y] += 2;
                            }
                        }
                    }

                    if (x <= PoleForm.velikostPole - 5 & y >= 5)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (znaky[x + 1, y - i] == "X")
                            {
                                hodnoty[x, y] += 2;
                            }
                        }
                    }

                    if (y <= PoleForm.velikostPole - 5 & x >= 5)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (znaky[x - 1, y + i] == "X")
                            {
                                hodnoty[x, y] += 2;
                            }
                        }
                    }

                    if (x <= PoleForm.velikostPole - 5 & y <= PoleForm.velikostPole - 5)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (znaky[x + i, y + 1] == "O")
                            {
                                hodnoty[x, y] += 1;
                            }
                        }
                    }

                    if (x >= 5 & y >= 5)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (znaky[x - i, y - 1] == "O")
                            {
                                hodnoty[x, y] += 1;
                            }
                        }
                    }

                    if (x <= PoleForm.velikostPole - 5 & y >= 5)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (znaky[x + 1, y - i] == "O")
                            {
                                hodnoty[x, y] += 1;
                            }
                        }
                    }

                    if (y <= PoleForm.velikostPole - 5 & x >= 5)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (znaky[x - 1, y + i] == "O")
                            {
                                hodnoty[x, y] += 1;
                            }
                        }
                    }

                    if (hodnoty[x, y] > max)
                    {
                        max = hodnoty[x, y];
                        this.x = x;
                        this.y = y;
                    }
                    if (hodnoty[x, y] == max)
                    {
                        nahoda = random.Next(0, 1);
                        if (nahoda == 0)
                        {
                            max = hodnoty[x, y];
                            this.x = x;
                            this.y = y;
                        }
                    }

                    break;
                case 1:



                    break;
            }
        }

    }
}
