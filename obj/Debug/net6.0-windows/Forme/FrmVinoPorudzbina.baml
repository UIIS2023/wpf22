   M S B A M L   `   `   `  ����C  ?Vinarija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Vinarija.FormeVinarija.Forme  5   	   &     Vinarija.Forme.FrmVinoPorudzbina   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Vinarija.Forme     5   	   
�������  � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ Poruzdbina vina��5
   	   $	��200��6!   $	��300��6.   .��5      � .+�5   
   �� $��Vino:��6   $
��Left=�6    $��	40,20,0,0q�6;   $	��Top=�6N   $��23��6f   �� 5   
   $��Porudžbina:��6   $
��Left=�6&   $��	40,60,0,0q�6A   $	��Top=�6T   $��23��6l   �� 5   
   -   5         ��Name$ cbVino��5      $
��Left=�6#   $��
130,20,0,0q�6>   $	��Top=�6R   $	��120��6j    �� DisplayMemberPath$ 	nazivVina��6v    �� SelectedValuePath$ vinoID��6�   �� 5   
   -   5        $ cbPorudzbina��5      $
��Left=�6)   $��
130,60,0,0q�6D   $	��Top=�6X   $	��120��6p   $ 
brojRacuna��6|   $ porudzbinaID��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   
�������$
��Left=�6S   $��
30,120,0,0q�6n   $��75��6�   $	��Top=�6�   6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkaži��6$   
�������$
��Left=�6Q   $��180,120,0,0q�6l   $��75��6�   $	��Top=�6�   6�   5      5      