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
        int hrac = 0;
        int smerx = 0;
        int smery = 0;
        int smerz = 0;
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
            this.hrac = hrac;
            for (int i = 0; i < PoleForm.velikostPole; i++)
            {
                for (int j = 0; j < PoleForm.velikostPole; j++)
                {
                    if (znaky[i ,j] == "")
                    {
                        //metoda Ohodnoceni
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
                default:
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

                    if (x >= 5)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (znaky[x, y - i] == "O")
                            {
                                hodnoty[x, y] += 1;
                            }
                        }
                    }

                    if (x >= PoleForm.velikostPole - 5)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (znaky[x, y + i] == "O")
                            {
                                hodnoty[x, y] += 1;
                            }
                        }
                    }

                    break;
                case 1:
                    break;
            }
        }

    }
}
