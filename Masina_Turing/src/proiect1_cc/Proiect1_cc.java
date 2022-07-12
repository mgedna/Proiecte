package proiect1_cc;

public class Proiect1_cc {
    public static void main(String[] args) throws Exception {
        MasinaTuring mt = new MasinaTuring("C:\\Users\\PC\\Desktop\\Masina_Turing\\src\\proiect1_cc\\mt.txt");
        if(mt.analizeazaCuvant("aabbbb")) 
        {
            System.out.println("Cuvantul este acceptat");
        }
        else
            System.out.println("Cuvantul nu este acceptat");
    }
}
