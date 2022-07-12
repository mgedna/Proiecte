package ebiblioteca;

import java.io.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.*;
import java.util.concurrent.TimeUnit;

public class Imprumut implements Comparable<Imprumut>
{
    private Persoana p;
    private Carte carte_aleasa;
    private double plata;
    private Date data_returnare, data_imprumut;
    private static TreeSet<Imprumut> imp = new TreeSet<>();

    public Imprumut(Persoana n, Carte ca, String di, String dr )
    {
        p = n;
        carte_aleasa= ca;
       try
        {
           data_imprumut = new SimpleDateFormat("dd/MM/yyyy").parse(di);
           data_returnare = new SimpleDateFormat("dd/MM/yyyy").parse(dr);
          
           long diferenta_milisec = Math.abs(data_returnare.getTime()-data_imprumut.getTime());
           long diferenta = TimeUnit.DAYS.convert(diferenta_milisec,TimeUnit.MILLISECONDS);
            
           plata = 0.5 * (diferenta+1);
            
        }catch(ParseException e)
        {
            e.printStackTrace();
        }
       imp.add(this);
       scriereImprumuturi();
    }
    
    public double getPlata()
    {
        return plata;
    }
    
    public Date getDataReturnare()
    {
        return data_returnare;
    }
    
    public Carte getCarte()
    {
        return carte_aleasa;
    }
    
    public Persoana getPersoana()
    {
        return p;
    }
    
    @Override
    public int compareTo(Imprumut i)
    { 
        return data_returnare.compareTo(i.data_returnare);
    }
        
    public String continutImprumut() //metoda folosita pentru scrierea in arhiva.txt si imprumuturi.txt
    {
        return getPersoana().toString()+"_"+carte_aleasa.afisareDate()+"_"+data(data_imprumut)+"_"+data(data_returnare)+"_"+plata;
    }
    
    public String data(Date d) //metoda folosita pentru afisarea in formatul dorit in fisiere
    {
        SimpleDateFormat f = new SimpleDateFormat("dd/MM/yyyy");
        return f.format(d);
    }
    
    public static ArrayList<Imprumut> cautaImprumuturi(String cnp)
    {  
        ArrayList<Imprumut> impr=new ArrayList();
        for(Imprumut i:imp)
        {
            if(i.p.getCod().equals(cnp))
            impr.add(i);
        }
        return impr; 
    }
    
    public void stergeImprumut()
    {
        try{
                PrintWriter pw=new PrintWriter(new FileWriter("arhiva.txt", true));
                pw.println(continutImprumut());
                pw.close();
            }catch(IOException ex){ex.printStackTrace();}
        imp.remove(this);
    }
    
    public static void scriereImprumuturi()
    {
        try{
                PrintWriter pw=new PrintWriter(new FileWriter("imprumuturi.txt"));
                for(Imprumut i:imp){
                pw.println(i.continutImprumut());}
                pw.close();
            }catch(IOException ex){ex.printStackTrace();}
    }
    
    public static void citireImprumuturi()
    {
        File f = new File("imprumuturi.txt");
        String[] s1,s2;
        String linie;
        Imprumut impr;
        BufferedReader br;
        
        if(f.exists())
        {
            try
            {
                br = new BufferedReader(new FileReader(f));
                while((linie = br.readLine())!=null)
                {
                    s1 = linie.split("_");
                    Persoana p=new Persoana(s1[0],s1[1]);
                    Carte c=new Carte(s1[2],s1[3],s1[4],Boolean.parseBoolean(s1[5]));
                    impr = new Imprumut(p,c,s1[6],s1[7]);
                    imp.add(impr);
                }
            }catch (IOException ioe)
            {
                ioe.printStackTrace();
            }
        }
        else
            System.out.println("Fisierul nu exista!");
    }  
}
