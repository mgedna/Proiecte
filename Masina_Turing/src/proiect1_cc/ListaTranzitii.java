package proiect1_cc;
import java.util.ArrayList;

public class ListaTranzitii {
    private ArrayList<Tranzitie> lista;

    public ListaTranzitii()
    {
        this.lista = new ArrayList<>();
    }

    void adaugaTranzitie(Tranzitie tr)
    {
        this.lista.add(tr);
    }

    Tranzitie gasesteTranzitie(String stare, char simbol)
    {
        for(int i=0; i<this.lista.size(); ++i)
        {
            Tranzitie t = this.lista.get(i);
            if(t.getSt_inceput().equals(stare) && t.getSimbolX() == simbol)
                return t;
        }
        return null;
    }
    
    int lungimeLista(){
        return lista.size();
    }
}
