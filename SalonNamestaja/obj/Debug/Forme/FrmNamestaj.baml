   M S B A M L   `   `   `  ����I  ESalonNamestaja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:SalonNamestaja.FormeSalonNamestaja.Forme  5   	   &     SalonNamestaja.Forme.FrmNamestaj   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:SalonNamestaja.Forme     5   	     � Title$  Dodaj/Izmeni��5   	   $	��330��6   $	��300��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��13* �6   �� 5      $	��12* �6   .+�5   
   �� $��Naziv proizvoda:��6   $
��Left=�6+   $��	30,20,0,0q�6F   $	��Top=�6Y   �� 5   
   $��Dostupnost:��6   $
��Left=�6&   $��	30,50,0,0q�6A   $	��Top=�6T   �� 5   
   $��Cena:��6   $
��Left=�6    $��	30,80,0,0q�6;   $	��Top=�6N   �� 5   
   $��Prostorija:��6   $
��Left=�6&   $��
30,110,0,0q�6A   $	��Top=�6U   �� 5   
   $��Proizvodjac:��6   $
��Left=�6'   $��
30,140,0,0q�6B   $	��Top=�6V   �� 5   
   $��Boja:��6   $
��Left=�6    $��
30,170,0,0q�6;   $	��Top=�6O   �� 5   
   $��
Materijal:��6   $
��Left=�6%   $��
30,200,0,0q�6@   $	��Top=�6T   �� 5   
   -   5         ��Name$ txtNazivProizvoda��5      $
��Left=�6-   $��23��6H   $��
135,20,0,0q�6T    �� TextWrapping$
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��120��6�   $��2��6�   �� 5   
   -   5         ��Name$ cbxDostupnost��5      $�� ��6*   $
��Left=�65   $��
135,55,0,0q�6P   $	��Top=�6d    d� 	IsChecked$
 TrueY�6|   �� 5   
   -   5        $ txtCena��5      $
��Left=�6#   $��23��6>   $��
135,80,0,0q�6J   $
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   $��2��6�   �� 5   
   -   5         ��Name$ cbProstorija��5      $
��Left=�6)   $��135,110,0,0q�6D   $	��Top=�6Y   $	��120��6q   $��2��6}    �� DisplayMemberPath$ nazivProstorije��6�    �� SelectedValuePath$ prostorijaID��6�   �� 5   
   -   5        $ cbProizvodjac��5      $
��Left=�6*   $��135,140,0,0q�6E   $	��Top=�6Z   $	��120��6r   $��2��6~   $ nazivProizvodjaca��6�   $ proizvodjacID��6�   �� 5   
   -   5        $ cbBoja��5      $
��Left=�6#   $��135,170,0,0q�6>   $	��Top=�6S   $	��120��6k   $��2��6w   $
 boja��6�   $ bojaID��6�   �� 5   
   -   5        $ cbMaterijal��5      $
��Left=�6(   $��135,200,0,0q�6C   $	��Top=�6X   $	��120��6p   $��2��6|   $ 	materijal��6�   $ materijalID��6�   �� 5   
   -   5        	 ��Name$	 
btnSacuvaj��5      $��Sačuvaj��6%   $
��Left=�67   $��
30,240,0,0q�6R   $	��Top=�6f   $��75��6~   6�   �� 5   
   -	   5        $	 	btnOtkazi��5      $��Otkaži��6$   $
��Left=�65   $��
24,240,0,0q�6P   $	��Top=�6d   $��75��6|   $��1��6�   6�   5      5      