   M S B A M L   `   `   `  ����U  QEB.BedrijfswagenBeheer.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:EB.BedrijfswagenBeheer.App.Views EB.BedrijfswagenBeheer.App.Views  5      7    1EB.BedrijfswagenBeheer.App.Views.FilialenListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:EB.BedrijfswagenBeheer.App.Views     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   6,   �� 5      6   �� 5      $
��auto �6   6,   .+�5   
   ��    
TitelStyle#��[  5      $��0��5      ��5      �� *Titel+5      �� 5   
   $��1��5      ��5      �� *
Filialen+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5      �� *SelectedFiliaal+5      �� 5   
   $��2��5      .@�5      �� $�� Verwijderen ��6   ��5      �� *DeleteCommand+5      �� 5       $��Wijzigen��6   ��5!      �� *EditCommand+��5"      �� *SelectedFiliaal+5#      �� 5$      $��	Toevoegen��6   ��5%      �� *
AddCommand+5&      5*      5+      5,      