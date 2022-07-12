package ebiblioteca;

import java.io.*;
import java.util.*;

public class Carte implements Comparable<Carte>
{
    private String cod_ISBN, titlu, editura;
    private boolean imprumutata;
    private static TreeSet<Carte> carti = new TreeSet<>(); //o colectie dinamica in care cartile sunt ordonate dupa codul lor
 
    public Carte(String cod_ISBN, String titlu, String editura, boolean imprumutata)
    {
        this.cod_ISBN = cod_ISBN;
        this.titlu = titlu;
        this.editura = editura;
        this.imprumutata = imprumutata;
    }
    
    public String getCod()
    {
        return cod_ISBN;
    }
    
    public String getTitlu()
    {
        return titlu;
    }
     
    public String getEditura()
    {
        return editura;
    }
      
    public boolean getStare()
    {
        return imprumutata;
    }

    public void setCod(String cod_nou)
    {
        cod_ISBN = cod_nou;
    }
    
    public void setTitlu(String titlu_nou)
    {
        titlu = titlu_nou;
    }
    
    public void setEditura(String editura_noua)
    {
        editura = editura_noua;
    }
    
    public void setStare(boolean stare_noua)
    {
        imprumutata = stare_noua;
    }
    
    @Override
    public int compareTo(Carte c)
    { 
        return cod_ISBN.compareTo(c.getCod());
    }
    
    public String infoCarte()
    {
        return titlu + "\nEditura: " + editura; //pentru afisare in JTextArea
    }
    
    public String afisareDate()
    {
        return cod_ISBN + "_"+titlu+"_"+editura+"_"+imprumutata; //pentru scrierea in arhiva.txt si imprumuturi.txt
    }
    
    public String toString()
    {
        return cod_ISBN+" "+titlu.replace(" ","_")+" "+editura+" "+imprumutata; //pentru scrierea in carti.txt
    }
    
    public static Carte cautaCarte(String cod) //metoda folosita in InterfataImprumut1 pentru a crea imprumutul conform codului selectat
    {
        for(Carte i:carti)
        {
            if(i.getCod().equals(cod))
                return i;
        }
        return null; 
    }
    
    public static Carte cautaTitlu(String cod) //metoda folosita in InterfataImprumut2 pentru a putea seta variabila imprumutata ca false dupa efectuarea returnarii
    {
        for(Carte i:carti)
        {
            if(i.getTitlu().equals(cod))
                return i;
        }
        return null; 
    }
    
    public static String[] coduri() //metoda pentru afisarea codurilor in JComboBox
    {
        ArrayList<String> coduri=new ArrayList<>();
        for(Carte i:carti)
            if(i.getStare()==false)
                coduri.add(i.getCod());
        return coduri.toArray(new String[coduri.size()]);
    }
    
    public static void citireCarti()
    {
        File f = new File("carti.txt");
        String[] s1,s2;
        String linie;
        Carte c;
        BufferedReader br;
        
        if(f.exists())
        {
            try
            {
                br = new BufferedReader(new FileReader(f));
                while((linie = br.readLine())!=null)
                {
                    s1 = linie.split(" ");
                    s2 = s1[1].split("_");
                    String nou=s2[0];
                    for(int i=1;i<s2.length;i++)
                        nou+=" "+s2[i];
                    c = new Carte(s1[0], nou, s1[2], Boolean.parseBoolean(s1[3]));
                    carti.add(c);
                }
            }catch (IOException ioe)
            {
                ioe.printStackTrace();
            }
        }
        else
            System.out.println("Fisierul nu exista!");
    }
    
    public static void salveaza()
    {
        try
        {
            PrintWriter pw = new PrintWriter(new FileWriter("carti.txt"));
            for(Carte f: carti) pw.println(f.toString());
            pw.close();
        }catch(IOException e)
        {
            e.printStackTrace();
        }
    }
}
