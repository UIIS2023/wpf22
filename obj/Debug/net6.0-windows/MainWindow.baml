   M S B A M L   `   `   `  ����C  ?Vinarija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:VinarijaVinarija  5   	       Vinarija.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Vinarija     5   	   
�������  � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ Vinarija��5
   	   $	��370��6   $	��650��6'   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridCentralni��5      $��Center=�6.   $
��auto��6K   $
��auto��6X   $��Center=�6f      
IsReadOnly$
 True��6�      AlternatingRowBackground
 �����   CanUserAddRows$ False��6�      SelectionUnit$ FullRow=�5         SelectionMode$ Single=�6+   �� 5   
   $��Center=�6   $	��Top=�62   $��30��6J   $
��auto��6V    �� Orientation$ 
Horizontal=�6c   $��1��6|   .+�5      �� -   5        	 ��Name$	 btnVino��5   \   
�������
�������
���**��$
��Vino��6m   $
��Left=�6|   $	��Top=�6�   $��70��6�   $��30��6�   6�   �� 5      -   5        $	 btnVrstaVina��5   \   
�������
�������
���**��$��Vrste��6r   $
��Left=�6�   $	��Top=�6�   $��70��6�   $��30��6�   6�   �� 5      -   5        $	 btnNivoSlatkoce��5   \   
�������
�������
���**��$��Nivo slatkoće��6u   $
��Left=�6�   $	��Top=�6�   $��75��6�   $��30��6�   6�   �� 5      -   5        $	 btnKorisnik��5   \   
�������
�������
���**��$��	Korisnici��6q   $
��Left=�6�   $	��Top=�6�   $��70��6�   $��30��6�   6�   �� 5      -   5        $	 btnKorisnickiNalog��5   \   
�������
�������
���**��$��Nalozi��6x   $
��Left=�6�   $	��Top=�6�   $��70��6�   $��30��6�   6�   �� 5      -   5        $	 btnDobavljac��5   \   
�������
�������
���**��$��Dobavljači��6r   $
��Left=�6�   $	��Top=�6�   $��70��6�   $��30��6�   6�   �� 5      -   5        $	 btnRecenzija��5   \   
�������
�������
���**��$��	Recenzije��6r   $
��Left=�6�   $	��Top=�6�   $��70��6�   $��30��6�   6�   �� 5      -	   5        $	 btnPorudzbina��5   \   
�������
�������
���**��$��Poručivanje��6s   $
��Left=�6�   $	��Top=�6�   $��70��6�   $��30��6�   6�   �� 5      -
   5        $	 btnVinoPorudzbina��5   \   
�������
�������
���**��$��Porudžbine��6w   $
��Left=�6�   $	��Top=�6�   $��70��6�   $��30��6�   6�   5      �� 5   
   $��Center=�6   $	��Top=�62   $��30��6J   $
��auto��6V   $ 
Horizontal=�6c   $��1��6|   $��	0,304,0,0q�6�   .+�5      �� -   5        $	 btnDodaj��5   -   
�������$��Dodaj��6?   $
��Left=�6O   $	��Top=�6k   $��75��6�   6�   �� 5      -   5        $	 btnIzmijeni��5   -   
�������$��Izmijeni��6B   $
��Left=�6U   $	��Top=�6q   $��75��6�   6�   �� 5      -   5        $	 	btnObrisi��5   -   
�������$��Obriši��6@   $
��Left=�6Q   $	��Top=�6m   $��75��6�   6�   5       5!      5"      