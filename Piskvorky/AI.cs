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
        //potřebné proměnné
        bool vyplneno = false;
        Random random = new Random();
        int randomX;
        int randomY;        
        int[,] hodnoty = new int[PoleForm.velikostPole, PoleForm.velikostPole];
        

        
        public AI()
        {

        }
        public void Lehky(string[,] znaky, ref int x, ref int y) //náhodný hráč
        {
            vyplneno = false;
            while (vyplneno == false) //pro případ, že by nalezl políčko, které je obsazené, je potřeba nekonečný cyklus, který se ukončí až po nalezení prázdného políčka
            {

                randomX = random.Next(0, PoleForm.velikostPole); //náhodné souřadnice
                randomY = random.Next(0, PoleForm.velikostPole);
                if (znaky[randomX, randomY] == "")
                {
                    x = randomX;
                    y = randomY;
                    vyplneno = true;
                }

            }
        }
        public void Stredni(string[,] znaky, string hrac, string protivnik, ref int nejX, ref int nejY)     //středně inteligentní počítač
        {

            int hracX = 0, hracY = 0, protivnikX = 0, protivnikY = 0, hracMax = 0, protivnikMax = 0;
            bool hracOhraniceni = false, protivnikOhraniceni = false; //ohraničení určuje, jestli je po určitém počtu určitého symbolu ve směru druhý znak, který by zabraňoval postupu
            // zde se určují priority, podle kterých počítač bude vybírat nejlepší pole

            ZjistiNejlepsiPole(znaky, ref hracX, ref hracY, ref hracMax, hrac, ref hracOhraniceni); //metoda pro nalezení nejvhodnějšího políčka
            if (hracMax == 5) // hráč může okamžitě vyhrát
            {
                nejX = hracX;
                nejY = hracY;
                return;
            }
            ZjistiNejlepsiPole(znaky, ref protivnikX, ref protivnikY, ref protivnikMax, protivnik, ref protivnikOhraniceni);
            if (protivnikMax == 5) //hráč může zabránit výhře nepřítele, pokud má nepřítel 4 neohraničené, je jedno kam zapíše svůj symbol
            {
                nejX = protivnikX;
                nejY = protivnikY;
                return;
            }
            if (hracMax == 4 && hracOhraniceni == false) //může vytvořit 4 neohraničené, a tím v podstatě vyhrát
            {
                nejX = hracX;
                nejY = hracY;
                return;
            }
            if (protivnikMax == 4 && protivnikOhraniceni == false) //může nepříteli zabránit vytvořit 4 neohraničené
            {
                nejX = protivnikX;
                nejY = protivnikY;
                return;
            }
            if (protivnikMax > hracMax && protivnikOhraniceni == false) //pokud má protivník více políček, a není ohraničen
            {
                nejX = protivnikX;
                nejY = protivnikY;
                return;
            }
            if (hracMax > protivnikMax && hracOhraniceni == false) //opačný případ
            {
                nejX = hracX;
                nejY = hracY;
                return;
            }
            if (hracMax > protivnikMax && hracOhraniceni == true) //pokud má hráč více políček, a je ohraničen
            {
                nejX = hracX;
                nejY = hracY;
            }
            if (protivnikMax > hracMax && protivnikOhraniceni == true) //pokud má protivník více políček, a je ohraničen
            {
                nejX = protivnikX;
                nejY = protivnikY;
                return;
            }
            if (hracMax == protivnikMax && hracOhraniceni == false) //bude hrát pro sebe, pokud mají stejně dlouhé řady, ale hráč není ohraničen
            {
                nejX = hracX;
                nejY = hracY;
                return;
            }
            if (hracMax == protivnikMax && protivnikOhraniceni == false) //tento případ nastane, pokud mají oba stejně, ale protihráč není ohraničen, zatímco hráč ano
            {
                nejX = protivnikX;
                nejY = protivnikY;
                return;
            }
            if (hracMax == protivnikMax && hracOhraniceni == true && protivnikOhraniceni == true) //oba mají stejně, a jsou ohraničení
            {
                nejX = hracX;
                nejY = hracY;
                return;
            }

            if (hracMax == 1 && protivnikMax == 1) // v případě, že počítač začíná, umístí symbol doprostřed
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
            else
            {
                nejX = hracX; //pro případ,že by nebyla splňena žádná podmínka, upřednostní hráčův nejlepší tah
                nejY = hracY;
                return;
            }
        }
        

        static void ZjistiNejlepsiPole(string[,] znaky, ref int nejX, ref int nejY, ref int max, string hrac, ref bool ohraniceni) 
        {
            nejX = 0;
            nejY = 0;
            max = 0; //říká, jak dlouhou řadu může vytvořit
            Random nahoda = new Random();
            int cislo;
            int smer1 = 0, smer2 = 0, smer3 = 0, smer4 = 0;
            
            ohraniceni = false; 
            for (int i = 0; i < PoleForm.velikostPole; i++)  //zde program začne projíždět v náhodném pořadí 4 směry a v něm vrátí nejlepší hodnoty
            {
                for (int j = 0; j < PoleForm.velikostPole; j++)
                {
                    if (znaky[i, j] == "")
                    {
                        smer1 = 0;
                        smer2 = 0;
                        smer3 = 0;
                        smer4 = 0;
                        cislo = 6;
                        while (cislo != smer1)      //zde se určí náhodné pořadí směrů
                        {
                            cislo = nahoda.Next(1, 5);
                            if (cislo != smer2 & cislo != smer3 & cislo != smer4)
                            {
                                smer1 = cislo;
                            }
                        }
                        while (cislo != smer2)
                        {
                            cislo = nahoda.Next(1, 5);
                            if (cislo != smer1 & cislo != smer3 & cislo != smer4)
                            {
                                smer2 = cislo;
                            }
                        }
                        while (cislo != smer3)
                        {
                            cislo = nahoda.Next(1, 5);
                            if (cislo != smer1 & cislo != smer2 & cislo != smer4)
                            {
                                smer3 = cislo;
                            }
                        }
                        while (cislo != smer4)
                        {
                            cislo = nahoda.Next(1, 5);
                            if (cislo != smer1 & cislo != smer2 & cislo != smer3)
                            {
                                smer4 = cislo;
                            }
                        }
                        ZjistiNejPoleProSmer(smer1, znaky, i, j, ref nejX, ref nejY, ref max, ref ohraniceni, hrac); //metody pro výpočet nejlepší souřadnice, hodnoty jak dlouhou řadu lze vytvořit, a také vrací jestli je řada ohraničena
                        ZjistiNejPoleProSmer(smer2, znaky, i, j, ref nejX, ref nejY, ref max, ref ohraniceni, hrac);
                        ZjistiNejPoleProSmer(smer3, znaky, i, j, ref nejX, ref nejY, ref max, ref ohraniceni, hrac);
                        ZjistiNejPoleProSmer(smer4, znaky, i, j, ref nejX, ref nejY, ref max, ref ohraniceni, hrac);
                    }
                }
            }
        }
        static void ZjistiNejPoleProSmer(int smer, string[,] iznaky, int poziceX, int poziceY, ref int nejX, ref int nejY, ref int max, ref bool ohraniceni, string hrac)
        {
            bool mistniOhraniceni = false;  //lokální proměnné
            int locMax = 1;
            bool locHledej = true;
            int locX = poziceX;
            int locY = poziceY;
            int cislo = 0;
            Random nahoda = new Random();
            switch (smer)  //zde se procházejí všechny směry
            {
                case 1:
                    
                    while (locHledej)
                    {
                        //doprava
                        if (locY + 1 == PoleForm.velikostPole)
                        { 
                            locHledej = false;
                            mistniOhraniceni = true;
                        }
                        else
                        {
                            locY++;
                            if (iznaky[locX, locY] != hrac)
                            {
                                if (iznaky[locX, locY] != "")
                                {
                                    mistniOhraniceni = true; //zde se určí ohraničení
                                }
                                locHledej = false;
                            }
                                
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
                        {
                            mistniOhraniceni = true;
                            locHledej = false;
                        }
                        else
                        {
                            locY--;
                            if (iznaky[locX, locY] != hrac)
                            {
                                if (iznaky[locX, locY] != "")
                                {
                                    mistniOhraniceni = true;
                                }
                                locHledej = false;
                            }
                            else
                                locMax++;
                        }
                    }

                    //porovnej s maximem
                    if ((locMax > max) || ((locMax == max) && (ohraniceni != mistniOhraniceni) && (mistniOhraniceni = false)))
                    {
                        max = locMax;
                        ohraniceni = mistniOhraniceni;      //zde se určí proměnné, které se předají do předchozí metody
                        nejX = poziceX;
                        nejY = poziceY;
                    }
                    else if ((locMax == max) && (ohraniceni == mistniOhraniceni))
                    {
                        cislo = nahoda.Next(0, 2);
                        if (cislo == 0)
                        {
                            nejX = poziceX;
                            nejY = poziceY;
                        }
                    }
                    break;

                case 2:
                    
                    while (locHledej)
                    {
                        //dolu
                        if (locX + 1 == PoleForm.velikostPole)
                        {
                            mistniOhraniceni = true;
                            locHledej = false;
                        }
                        else
                        {
                            locX++;
                            if (iznaky[locX, locY] != hrac)
                            {
                                if (iznaky[locX, locY] != "")
                                {
                                    mistniOhraniceni = true;
                                }
                                locHledej = false;
                            }

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
                        {
                            mistniOhraniceni = true;
                            locHledej = false;
                        }
                        else
                        {
                            locX--;
                            if (iznaky[locX, locY] != hrac)
                            {
                                if (iznaky[locX, locY] != "")
                                {
                                    mistniOhraniceni = true;
                                }
                                locHledej = false;
                            }
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
                    else if ((locMax == max) && (ohraniceni == mistniOhraniceni))
                    {
                        cislo = nahoda.Next(0, 2);
                        if (cislo == 0)
                        {
                            nejX = poziceX;
                            nejY = poziceY;
                        }
                    }
                    break;

                case 3:
                    //diagonalne zleva doprava nahoru
                    while (locHledej)
                    {
                        //doprava nahoru
                        if ((locY + 1 == PoleForm.velikostPole) || (locX - 1 == -1))
                        {
                            mistniOhraniceni = true;
                            locHledej = false;
                        }
                        else
                        {
                            locY++;
                            locX--;
                            if (iznaky[locX, locY] != hrac)
                            {
                                if (iznaky[locX, locY] != "")
                                {
                                    mistniOhraniceni = true;
                                }
                                locHledej = false;
                            }
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
                        {
                            mistniOhraniceni = true;
                            locHledej = false;
                        }
                        else
                        {
                            locY--;
                            locX++;
                            if (iznaky[locX, locY] != hrac)
                            {
                                if (iznaky[locX, locY] != "")
                                {
                                    mistniOhraniceni = true;
                                }
                                locHledej = false;
                            }
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
                    else if ((locMax == max) && (ohraniceni == mistniOhraniceni))
                    {
                        cislo = nahoda.Next(0, 2);
                        if (cislo == 0)
                        {
                            nejX = poziceX;
                            nejY = poziceY;
                        }
                    }
                    break;

                case 4:
                    //diagonalne zleva doprava dolu
                   
                    while (locHledej)
                    {
                        //doprava dolu
                        if ((locY + 1 == PoleForm.velikostPole) || (locX + 1 == PoleForm.velikostPole))
                        {
                            mistniOhraniceni = true;
                            locHledej = false;
                        }
                        else
                        {
                            locY++;
                            locX++;
                            if (iznaky[locX, locY] != hrac)
                            {
                                if (iznaky[locX, locY] != "")
                                {
                                    mistniOhraniceni = true;
                                }
                                locHledej = false;
                            }
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
                        {
                            mistniOhraniceni = true;
                            locHledej = false;
                        }
                        else
                        {
                            locY--;
                            locX--;
                            if (iznaky[locX, locY] != hrac)
                            {
                                if (iznaky[locX, locY] != "")
                                {
                                    mistniOhraniceni = true;
                                }
                                locHledej = false;
                            }
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
                    else if ((locMax == max) && (ohraniceni == mistniOhraniceni))
                    {
                        cislo = nahoda.Next(0, 2);
                        if (cislo == 0)
                        {
                            nejX = poziceX;
                            nejY = poziceY;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
