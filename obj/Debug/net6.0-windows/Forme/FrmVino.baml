   M S B A M L   `   `   `  ����C  ?Vinarija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Vinarija.FormeVinarija.Forme  5   	       Vinarija.Forme.FrmVino   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Vinarija.Forme     5   	   
�������  � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ Dodaj/Izmijeni vino��5
   	   $	��300��6%   $	��300��62   .��5      � .+�5   
   �� $��Naziv vina:��6   $
��Left=�6&   $��	30,20,0,0q�6A   $	��Top=�6T   $��23��6l   �� 5   
   $��Godina proizvodnje:��6   $
��Left=�6.   $��	30,50,0,0q�6I   $	��Top=�6\   $��23��6t   �� 5   
   $��Vrsta vina:��6   $
��Left=�6&   $��	30,80,0,0q�6A   $	��Top=�6T   $��23��6l   �� 5   
   $��Nivo slatkoce:��6   $
��Left=�6)   $��
30,110,0,0q�6D   $	��Top=�6X   $��23��6p   �� 5   
   $��
Recenzija:��6   $
��Left=�6%   $��
30,140,0,0q�6@   $	��Top=�6T   $��23��6l   �� 5   
   $��
Dobavljac:��6   $
��Left=�6%   $��
30,170,0,0q�6@   $	��Top=�6T   $��23��6l   �� 5   
   -   5         ��Name$ txtNazivVina��5      $
��Left=�6)   $��
145,20,0,0q�6D    �� TextWrapping$
 Wrap=�6X   $�� ��6l   $	��Top=�6t   $��23��6�   $	��120��6�   �� 5   
   -   5        $ txtGodinaProizvodnje��5      $
��Left=�61   $��
145,50,0,0q�6L   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $��23��6�   $	��120��6�   �� 5   
   -   5         ��Name$ cbVrstaVina��5      $
��Left=�6(   $��
145,80,0,0q�6C   $	��Top=�6W   $	��120��6o    �� DisplayMemberPath$ 	vrstaVina��6{    �� SelectedValuePath$ vrstaVinaID��6�   �� 5   
   -   5        $ cbNivoSlatkoce��5      $
��Left=�6+   $��145,110,0,0q�6F   $	��Top=�6[   $	��120��6s   $ nivoSlatkoce��6   $ nivoSlatkoceID��6�   �� 5   
   -   5        $ cbRecenzija��5      $
��Left=�6(   $��145,140,0,0q�6C   $	��Top=�6X   $	��120��6p   $ komentar��6|   $ recenzijaID��6�   �� 5   
   -   5        $ cbDobavljac��5      $
��Left=�6(   $��145,170,0,0q�6C   $	��Top=�6X   $	��120��6p   $ imeDobavljaca��6|   $ dobavljacID��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   
�������$
��Left=�6S   $��
30,230,0,0q�6n   $��75��6�   $	��Top=�6�   6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkaži��6$   
�������$
��Left=�6Q   $��180,230,0,0q�6l   $��75��6�   $	��Top=�6�   6�   5      5      