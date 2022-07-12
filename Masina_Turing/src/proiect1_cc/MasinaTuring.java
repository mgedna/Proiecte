package proiect1_cc;
import java.io.BufferedReader;
import java.io.FileReader;

public class MasinaTuring
{
    private String st_initiala = "q0";
    private String st_finale_str;
    private ListaTranzitii lt=new ListaTranzitii();
    private String cuvant_rezultat = "";
    private String[] stari_finale;

    // Input: st_init st_finala caracter_gasit caracter_scris deplasare

    MasinaTuring(String nume_fisier) throws Exception
    {
        BufferedReader buf=new BufferedReader(new FileReader(nume_fisier));
        this.st_initiala = buf.readLine();
        st_finale_str = buf.readLine();
        while(true)
        {
            String tmp=buf.readLine();
            if(tmp==null)
                break;
            String tmpbl[]=tmp.split(" ");
            Tranzitie tr=new Tranzitie(tmpbl[0], tmpbl[1], tmpbl[2].charAt(0), tmpbl[3].charAt(0), tmpbl[4].charAt(0));
            lt.adaugaTranzitie(tr);
        }
        stari_finale=st_finale_str.split(" ");
    }

    boolean analizeazaCuvant (String cuvant) throws Exception
    {
        int i=0;
        String st_curenta = st_initiala;
        cuvant = 'B' + cuvant + 'B';
        while(true)
        {   if(i<0){
                System.out.println("Sarim de pe banda");
                return false;
            }
            Tranzitie tranz = lt.gasesteTranzitie(st_curenta, cuvant.charAt(i));
            if (tranz != null)
            {       cuvant=cuvant+'B';
                    StringBuilder cuvant2 = new StringBuilder(cuvant);
                    cuvant2.setCharAt(i, tranz.getSimbolY()); //rescriem simbolul x cu simbolul y
                    cuvant = cuvant2.toString(); //actualizam cuvantul initial
                    System.out.println(cuvant);
                    for(int j=0;j<i;j++)
                        System.out.print(" ");
                    System.out.print("^");
                    System.out.println();
                    if (tranz.getDeplasare() == 'L')
                        --i;
                    else
                        if (tranz.getDeplasare() == 'R')
                            ++i;
                st_curenta = tranz.getSt_sfarsit();
                for (int j = 0; j < stari_finale.length; j++)
                    if (st_curenta.equals(stari_finale[j]))
                        return true;
            }
            else
                return false;
        }
    }
}
