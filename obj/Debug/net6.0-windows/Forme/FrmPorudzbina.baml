   M S B A M L   `   `   `  ����C  ?Vinarija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Vinarija.FormeVinarija.Forme  5   	   "    Vinarija.Forme.FrmPorudzbina   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Vinarija.Forme     5   	   
�������  � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ Porucivanje��5
   	   $	��270��6   $	��300��6*   .��5      � .+�5   
   �� $��Količina proizvoda:��6   $
��Left=�6.   $��	28,20,0,0q�6I   $	��Top=�6\   $��23��6t   �� 5   
   -   5         ��Name$ txtKolicinaProizvoda��5      $
��Left=�61   $��
140,20,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $��23��6�   $	��120��6�   �� 5   
   $��Datum:��6   $
��Left=�6!   $��	28,50,0,0q�6<   $	��Top=�6O   $��23��6g   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpDatum��5      $��Center=�6&   $��	85,50,0,0q�6C   $	��Top=�6V   �� 5   
   $��Broj računa:��6   $
��Left=�6'   $��	28,80,0,0q�6B   $	��Top=�6U   $��23��6m   �� 5   
   -   5        $ txtBrojRacuna��5      $
��Left=�6*   $��
140,80,0,0q�6E   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $��23��6�   $	��120��6�   �� 5   
   $��Cijena:��6   $
��Left=�6"   $��
28,110,0,0q�6=   $	��Top=�6Q   $��23��6i   �� 5   
   -   5        $ 	txtCijena��5      $
��Left=�6&   $��140,110,0,0q�6A   $
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $��23��6�   $	��120��6�   �� 5   
   $��
Korisnik: ��6   $
��Left=�6%   $��
28,140,0,0q�6@   $	��Top=�6T   $��23��6l   �� 5   
   -   5         ��Name$ 
cbKorisnik��5      $
��Left=�6'   $��140,140,0,0q�6B   $	��Top=�6W   $	��120��6o    �� DisplayMemberPath$ imeKorisnika��6{    �� SelectedValuePath$ 
korisnikID��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   
�������$
��Left=�6S   $��
30,200,0,0q�6n   $��75��6�   $	��Top=�6�   6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkaži��6$   
�������$
��Left=�6Q   $��180,200,0,0q�6l   $��75��6�   $	��Top=�6�   6�   5      5      