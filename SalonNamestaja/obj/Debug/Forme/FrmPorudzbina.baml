   M S B A M L   `   `   `  ����I  ESalonNamestaja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:SalonNamestaja.FormeSalonNamestaja.Forme  5   	   (    "SalonNamestaja.Forme.FrmPorudzbina   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:SalonNamestaja.Forme     5   	     � Title$  Dodaj/Izmeni��5   	   $	��380��6   $	��300��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��13* �6   �� 5      $	��12* �6   .+�5   
   �� $��Adresa Isporuke:��6   $
��Left=�6+   $��	30,20,0,0q�6F   $	��Top=�6Y   �� 5   
   $��Nacin Isporuke:��6   $
��Left=�6*   $��	30,50,0,0q�6E   $	��Top=�6X   �� 5   
   $��Rok Isporuke:��6   $
��Left=�6(   $��	30,80,0,0q�6C   $	��Top=�6V   �� 5   
   $��Vreme:��6   $
��Left=�6!   $��
30,110,0,0q�6<   $	��Top=�6P   �� 5   
   $��Datum:��6   $
��Left=�6!   $��
30,140,0,0q�6<   $	��Top=�6P   �� 5   
   $��Kupac:��6   $
��Left=�6!   $��
30,170,0,0q�6<   $	��Top=�6P   �� 5   
   $��	Prodavac:��6   $
��Left=�6$   $��
30,200,0,0q�6?   $	��Top=�6S   �� 5   
   $��Naziv proizvoda:��6   $
��Left=�6+   $��
30,230,0,0q�6F   $	��Top=�6Z   �� 5   
   $��Dostavljac:��6   $
��Left=�6&   $��
30,260,0,0q�6A   $	��Top=�6U   �� 5   
   -   5         ��Name$ txtAdresaIsporuke��5      $
��Left=�6-   $��23��6H   $��
135,20,0,0q�6T    �� TextWrapping$
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��120��6�   $��2��6�   �� 5   
   -   5        $ txtNacinIsporuke��5      $
��Left=�6,   $��23��6G   $��
135,50,0,0q�6S   $
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��120��6�   $��2��6�   �� 5   
   -   5        $ txtRokIsporuke��5      $
��Left=�6*   $��23��6E   $��
135,80,0,0q�6Q   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��120��6�   $��2��6�   �� 5   
   -   5        $ txtVreme��5      $
��Left=�6$   $��23��6?   $��135,110,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��120��6�   $��2��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpDatum��5      $
��Left=�6$   $��135,140,0,0q�6?   $	��Top=�6T   $��2��6l   �� 5   
   -   5         ��Name$ cbKupac��5      $
��Left=�6$   $��135,170,0,0q�6?   $	��Top=�6T   $	��120��6l   $��2��6x    �� DisplayMemberPath$ Ime i prezime��6�    �� SelectedValuePath$ kupacID��6�   �� 5   
   -   5        $ 
cbProdavac��5      $
��Left=�6'   $��135,200,0,0q�6B   $	��Top=�6W   $	��120��6o   $��2��6{   $ Ime i Prezime��6�   $ 
prodavacID��6�   �� 5   
   -   5        $ 
cbNamestaj��5      $
��Left=�6'   $��135,230,0,0q�6B   $	��Top=�6W   $	��120��6o   $��2��6{   $ nazivProizvoda��6�   $ 
namestajID��6�   �� 5    
   -	   5        $ cbDostavljac��5       $
��Left=�6)   $��135,260,0,0q�6D   $	��Top=�6Y   $	��120��6q   $��2��6}   $ dostavljacFull��6�   $ dostavljacID��6�   �� 5!   
   -
   5         ��Name$ 
btnSacuvaj��5!      $��Sačuvaj��6%   $
��Left=�67   $��
30,310,0,0q�6R   $	��Top=�6f   $��75��6~   6�   �� 5"   
   -   5        $ 	btnOtkazi��5"      $��Otkaži��6$   $
��Left=�65   $��
24,310,0,0q�6P   $	��Top=�6d   $��75��6|   $��1��6�   6�   5$      5%      