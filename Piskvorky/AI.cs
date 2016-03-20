using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piskvorky
{
    class AI
    {
        //PoleForm poleForm = new PoleForm();
        bool vyplneno = false;
        Random random = new Random();
        int randomX;
        int randomY;        
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
        public void Stredni(string[,] znaky, string hrac, string protivnik, ref int nejX, ref int nejY)
        {

            int hracX = 0, hracY = 0, protivnikX = 0, protivnikY = 0, hracMax = 0, protivnikMax = 0;
            bool hracOhraniceni = false, protivnikOhraniceni = false;
            // 1) výhra hráče

            ZjistiNejlepsiPole(znaky, ref hracX, ref hracY, ref hracMax, hrac, ref hracOhraniceni);
            if (hracMax == 5)
            {
                nejX = hracX;
                nejY = hracY;
                return;
            }
            ZjistiNejlepsiPole(znaky, ref protivnikX, ref protivnikY, ref protivnikMax, protivnik, ref protivnikOhraniceni);
            if (protivnikMax == 5)
            {
                nejX = protivnikX;
                nejY = protivnikY;
                return;
            }
            if (hracMax == 4 & hracOhraniceni == false)
            {
                nejX = hracX;
                nejY = hracY;
                return;
            }
            if (protivnikMax == 4 & protivnikOhraniceni == false)
            {
                nejX = protivnikX;
                nejY = protivnikY;
                return;
            }
            if (protivnikMax > hracMax & protivnikOhraniceni == false)
            {
                nejX = protivnikX;
                nejY = protivnikY;
                return;
            }
            if (hracMax > protivnikMax & hracOhraniceni == false)
            {
                nejX = hracX;
                nejY = hracY;
                return;
            }
            if (hracMax == protivnikMax & hracOhraniceni == false)
            {
                nejX = hracX;
                nejY = hracY;
                return;
            }
            if (hracMax == protivnikMax & protivnikOhraniceni == false)
            {
                nejX = protivnikX;
                nejY = protivnikY;
                return;
            }
            if (hracOhraniceni == false & protivnikOhraniceni == true)
            {
                nejX = hracX;
                nejY = hracY;
            }
            if (hracOhraniceni == true & protivnikOhraniceni == false)
            {
                nejX = protivnikX;
                nejY = protivnikY;
                return;
            }
            if (hracMax == 1 & protivnikMax == 1)
            {
                if (PoleForm.velikostPole == 10)
                {
                    nejX = 4;
                    nejY = 4;
                    return;
                }
                if (PoleForm.velikostPole == 20)
                {
                    nejX = 9;
                    nejY = 9;
                    return;
                }
            }
            nejX = hracX;
            nejY = hracY;
            return;

        }
        

        static void ZjistiNejlepsiPole(string[,] znaky, ref int nejX, ref int nejY, ref int max, string hrac, ref bool ohraniceni)
        {
            nejX = 0;
            nejY = 0;
            max = 0;
            ohraniceni = false;
            for (int i = 0; i < PoleForm.velikostPole; i++)
            {
                for (int j = 0; j < PoleForm.velikostPole; j++)
                {
                    if (znaky[i, j] == "")
                    {
                        for (int smer = 1; smer < 5; smer++)
                        {
                            
                            ZjistiNejPoleProSmer(smer, znaky, i, j, ref nejX, ref nejY, ref max, ref ohraniceni, hrac);
                            
                        }
                    }
                }
            }
        }
        static void ZjistiNejPoleProSmer(int smer, string[,] iznaky, int poziceX, int poziceY, ref int nejX, ref int nejY, ref int max, ref bool ohraniceni, string hrac)
        {
            bool mistniOhraniceni = false;
            int locMax = 1;
            bool locHledej = true;
            int locX = poziceX;
            int locY = poziceY;
            switch (smer)
            {
                case 1:
                    //horizontalne
                    if (((locY + 1) == PoleForm.velikostPole) || ((locY - 1) == -1))
                        mistniOhraniceni = true;
                    while (locHledej)
                    {
                        //doprava
                        if (locY + 1 == PoleForm.velikostPole)
                            locHledej = false;
                        else
                        {
                            locY++;
                            if (iznaky[locX, locY] != hrac)
                                locHledej = false;
                            else
                                locMax++;
                        }
                    }

                    locHledej = true;
                    locX = poziceX;
                    locY = poziceY;
                    while (locHledej)
                    {
                        //doleva
                        if (locY - 1 == -1)
                            locHledej = false;
                        else
                        {
                            locY--;
                            if (iznaky[locX, locY] != hrac)
                                locHledej = false;
                            else
                                locMax++;
                        }
                    }

                    //porovnej s maximem
                    if ((locMax > max) || ((locMax == max) && (ohraniceni != mistniOhraniceni) && (mistniOhraniceni = false)))
                    {
                        max = locMax;
                        ohraniceni = mistniOhraniceni;
                        nejX = poziceX;
                        nejY = poziceY;
                    }
                    break;

                case 2:
                    //vertikalne
                    if (((locX + 1) == PoleForm.velikostPole) || ((locX - 1) == -1))
                        mistniOhraniceni = true;
                    while (locHledej)
                    {
                        //dolu
                        if (locX + 1 == PoleForm.velikostPole)
                            locHledej = false;
                        else
                        {
                            locX++;
                            if (iznaky[locX, locY] != hrac)
                                locHledej = false;
                            else
                                locMax++;
                        }
                    }

                    locHledej = true;
                    locX = poziceX;
                    locY = poziceY;
                    while (locHledej)
                    {
                        //nahoru
                        if (locX - 1 == -1)
                            locHledej = false;
                        else
                        {
                            locX--;
                            if (iznaky[locX, locY] != hrac)
                                locHledej = false;
                            else
                                locMax++;
                        }
                    }

                    //porovnej s maximem
                    if ((locMax > max) || ((locMax == max) && (ohraniceni != mistniOhraniceni) && (mistniOhraniceni = false)))
                    {
                        max = locMax;
                        ohraniceni = mistniOhraniceni;
                        nejX = poziceX;
                        nejY = poziceY;
                    }
                    break;

                case 3:
                    //diagonalne zleva doprava nahoru
                    if (((locX + 1) == PoleForm.velikostPole) || ((locX - 1) == -1) || ((locY + 1) == PoleForm.velikostPole) || ((locY - 1) == -1))
                        mistniOhraniceni = true;
                    while (locHledej)
                    {
                        //doprava nahoru
                        if ((locY + 1 == PoleForm.velikostPole) || (locX - 1 == -1))
                            locHledej = false;
                        else
                        {
                            locY++;
                            locX--;
                            if (iznaky[locX, locY] != hrac)
                                locHledej = false;
                            else
                                locMax++;
                        }
                    }

                    locHledej = true;
                    locX = poziceX;
                    locY = poziceY;
                    while (locHledej)
                    {
                        //doleva dolu
                        if ((locY - 1 == -1) || (locX + 1 == PoleForm.velikostPole))
                            locHledej = false;
                        else
                        {
                            locY--;
                            locX++;
                            if (iznaky[locX, locY] != hrac)
                                locHledej = false;
                            else
                                locMax++;
                        }
                    }

                    //porovnej s maximem
                    if ((locMax > max) || ((locMax == max) && (ohraniceni != mistniOhraniceni) && (mistniOhraniceni = false)))
                    {
                        max = locMax;
                        ohraniceni = mistniOhraniceni;
                        nejX = poziceX;
                        nejY = poziceY;
                    }
                    break;

                case 4:
                    //diagonalne zleva doprava dolu
                    if (((locX + 1) == PoleForm.velikostPole) || ((locX - 1) == -1) || ((locY + 1) == PoleForm.velikostPole) || ((locY - 1) == -1))
                        mistniOhraniceni = true;
                    while (locHledej)
                    {
                        //doprava dolu
                        if ((locY + 1 == PoleForm.velikostPole) || (locX + 1 == PoleForm.velikostPole))
                            locHledej = false;
                        else
                        {
                            locY++;
                            locX++;
                            if (iznaky[locX, locY] != hrac)
                                locHledej = false;
                            else
                                locMax++;
                        }
                    }

                    locHledej = true;
                    locX = poziceX;
                    locY = poziceY;
                    while (locHledej)
                    {
                        //doleva nahoru
                        if ((locY - 1 == -1) || (locX - 1 == -1))
                            locHledej = false;
                        else
                        {
                            locY--;
                            locX--;
                            if (iznaky[locX, locY] != hrac)
                                locHledej = false;
                            else
                                locMax++;
                        }
                    }

                    //porovnej s maximem
                    if ((locMax > max) || ((locMax == max) && (ohraniceni != mistniOhraniceni) && (mistniOhraniceni = false)))
                    {
                        max = locMax;
                        ohraniceni = mistniOhraniceni;
                        nejX = poziceX;
                        nejY = poziceY;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
