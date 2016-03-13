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
        int hodnota = 0;
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
        public void Stredni(string[,] znaky, ref int x, ref int y)
        {

            vyplneno = false;
            while (vyplneno == false)
            {
                for (int i = 0; i < PoleForm.velikostPole - 4; i++)
                {
                    for (int j = 0; j < PoleForm.velikostPole; j++)
                    {
                        if (znaky[i + 1, j] != "X" & znaky[i + 2, j] != "X" & znaky[i + 3, j] != "X" & znaky[i + 4, j] != "X")
                        {
                            if (5 > hodnota & znaky[i, j] == "")
                            {
                                hodnota = 5;
                                x = i;
                                y = j;
                            }
                         vyplneno = true;                            
                        }
                        if (znaky[i + 1, j] != "O" & znaky[i + 2, j] != "O" & znaky[i + 3, j] != "O" & znaky[i + 4, j] != "X")
                        {
                            if (4 > hodnota & znaky[i, j] == "")
                            {
                                hodnota = 4;
                                x = i;
                                y = j;
                            }
                            vyplneno = true;
                        }
                        
                    }
                }
                


            }

        }
    }
}
