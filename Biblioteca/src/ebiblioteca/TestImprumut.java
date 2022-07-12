package ebiblioteca;

public class TestImprumut 
{
       public static void main(String [] args)
       {
           
           Persoana p = new Persoana ("Ionescu Ion", "25644");
           
           Carte c = new Carte("12653325","Ana", "Astras", false);
           Carte c2 = new Carte("42","Ion", "Valeriu", false);
          /* Imprumut i = new Imprumut(p, c, "12/01/2022", "17/01/2022");
           Imprumut i2 = new Imprumut(p, c2, "12/01/2022", "17/01/2022");
           for(Imprumut contor:i.getImprumuturi())
               System.out.println(contor.getPlata());*/
       }
}
