package proiect1_cc;
import java.util.Objects;

public class Tranzitie
{
    private String st_inceput, st_sfarsit;
    private char simbolX, simbolY, deplasare;

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Tranzitie tranzitie = (Tranzitie) o;
        return simbolX == tranzitie.simbolX && simbolY == tranzitie.simbolY && deplasare == tranzitie.deplasare && Objects.equals(st_inceput, tranzitie.st_inceput) && Objects.equals(st_sfarsit, tranzitie.st_sfarsit);
    }

/*    @Override
    public int hashCode() {
        return Objects.hash(st_inceput, st_sfarsit, simbolX, simbolY, deplasare);
    }*/

    public Tranzitie(String st_inceput, String st_sfarsit, char simbolX, char simbolY, char deplasare)
    {
        this.st_inceput = st_inceput;
        this.st_sfarsit = st_sfarsit;
        this.simbolX = simbolX;
        this.simbolY = simbolY;
        this.deplasare = deplasare;
    }

    public String getSt_inceput() {
        return st_inceput;
    }

    public String getSt_sfarsit() {
        return st_sfarsit;
    }

    public char getSimbolX() {
        return simbolX;
    }

    public char getSimbolY() {
        return simbolY;
    }

    public char getDeplasare() {
        return deplasare;
    }
}
