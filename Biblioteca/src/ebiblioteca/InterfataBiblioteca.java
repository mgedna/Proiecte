package ebiblioteca;

import java.awt.*;
import javax.swing.*;
import java.awt.event.*;

public class InterfataBiblioteca extends JFrame  
{
    JButton bImprumut, bInapoiere;
    JPanel p;
    
    InterfataBiblioteca()
    {
        super("Biblioteca");
        Imprumut.citireImprumuturi();
        Carte.citireCarti();
        AscultatorBiblioteca ab = new AscultatorBiblioteca();
        bImprumut = new JButton("Imprumut");
        bImprumut.setFont(new Font("Cascadia Code SemiBold", Font.BOLD, 13));
        bImprumut.setBackground(new Color(255,228,196));
        bInapoiere = new JButton("Returnare");
        bInapoiere.setFont(new Font("Cascadia Code SemiBold", Font.BOLD, 13));
        bInapoiere.setBackground(new Color(255,228,196));
        bImprumut.addActionListener(ab);
        bInapoiere.addActionListener(ab);
        p = new JPanel();
        p.add(bImprumut);
        p.add(bInapoiere);
        getContentPane().add(p);
        p.setBackground(new Color(253,245,230));
        setPreferredSize(new Dimension(300,80));
        
        pack();
        setLocationRelativeTo(null);
        setVisible(true);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    }
    
    class AscultatorBiblioteca implements ActionListener
    {
        private JFrame f;
        
        public void actionPerformed(ActionEvent e)
        {
            if (e.getSource()==bImprumut)
            { 
                Imprumut.scriereImprumuturi();
                f = new InterfataImprumut1();
                f.pack();
                f.setVisible(true);
            }
            else
                if (e.getSource()==bInapoiere)
            {  
                Imprumut.scriereImprumuturi();
                f = new InterfataReturnare();
                f.pack();
                f.setVisible(true);
            }
        }
    } 
    
    
}

