   M S B A M L   `   `   `  ����I  ESalonNamestaja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SalonNamestajaSalonNamestaja  5   	       SalonNamestaja.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SalonNamestaja     5   	     � Title$  Salon Namestaja��5   	   $	��360��6!   $	��760��6.   .��5	      � ��5
   
   �� 5       �� ImageSource$0 *C:\Users\marko\OneDrive\Desktop\salon1.jpg��6    j� Stretch$ UniformToFill=�6R   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGridCentralni��5      $��Center=�6,   $��Center=�6I   $
��auto��6d   $
��auto��6r      
IsReadOnly .    AlternatingRowBackground
 �����   CanUserAddRows .     SelectionUnit$ FullRow=�5   H      SelectionMode$ Single=�6`   �� 5   
   $��Center=�6   $��30��62   $	��Top=�6?   $
��auto��6W    �� Orientation$ 
Horizontal=�6d   .+�5      �� -   5        	 ��Name$	 btnNamestaj��5      $��Namestaj��6*   $
��Left=�6=   $��30��6X   $	��Top=�6d   $��75��6|   6�   �� 5      -   5        $	 btnProizvodjac��5      $��Proizvodjac��6-   $
��Left=�6C   $��30��6^   $	��Top=�6j   $��75��6�   6�   �� 5      -   5        $	 btnProstorija��5      $��
Prostorija��6,   $
��Left=�6A   $��30��6\   $	��Top=�6h   $��75��6�   6�   �� 5      -   5        $	 btnBoja��5      $
��Boja��6&   $
��Left=�65   $��30��6P   $	��Top=�6\   $��75��6t   6   �� 5      -   5        $	 btnMaterijal��5      $��	Materijal��6+   $
��Left=�6?   $��30��6Z   $	��Top=�6f   $��75��6~   6�   �� 5      -   5        $	 btnPorudzbina��5      $��
Porudzbina��6,   $
��Left=�6A   $��30��6\   $	��Top=�6h   $��75��6�   6�   �� 5      -   5        $	 btnDostavljac��5      $��
Dostavljac��6,   $
��Left=�6A   $��30��6\   $	��Top=�6h   $��75��6�   6�   �� 5      -	   5        $	 btnKupac��5      $��Kupac��6'   $
��Left=�67   $��30��6R   $	��Top=�6^   $��75��6v   6�   �� 5      -
   5        $	 btnProdavac��5      $��Prodavac��6*   $
��Left=�6=   $��30��6X   $	��Top=�6d   $��75��6|   6�   5      �� 5   
   $��Center=�6   $��30��62   $��Bottom=�6?   $	��360��6Z   $ 
Horizontal=�6f   .+�5      �� -   5        $	 btnDodaj��5      $��Dodaj��6'   $	��120��67   6C   �� 5      -   5        $	 	btnIzmeni��5      $��Izmeni��6(   $	��120��69   6E   �� 5      -   5        $	 	btnObrisi��5      $��Obriši��6(   $	��120��69   6E   5       5!      5"      