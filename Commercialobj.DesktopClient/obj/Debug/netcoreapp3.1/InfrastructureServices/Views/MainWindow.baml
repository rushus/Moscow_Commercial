   M S B A M L   `   `   `  ����V  RCommercialobj.DesktopClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Commercialobj.DesktopClientCommercialobj.DesktopClient  5   	   ,    &Commercialobj.DesktopClient.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Commercialobj.DesktopClient     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	         Montserrat-Medium��%S   &	        *�5
   
   1-pack://application:,,,/Fonts/#Med Uch Regular)�5      5      .��5      � #��[  6   $��14(�6E    � ColumnDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��5q�6"   
���  ��
���������6R   �� *Commercialobjs+ �� SelectedItem 6y   �� *CurrentCommercialobj+��5      �� 5      .R�5      �� $��5q�6!   .+�5      �� $��14(�6$   ��62   ��  �� Path$
 Name�5      5      5      �� 5   
   $��1��6   $��0,0,0,0q�6R    � DataContext 6%   �� *CurrentCommercialobj+.+�5      ��  �� Padding$ 3q�6   $
��Bold"�6$   $��
More info:��66   $��Center=�6H   �� 5       $ 2q�6   $
��Wrap=�6$   ��68   ��  �� StringFormat$ 	Name: {0}��$
 Name��� 5!      $ 2q�6   $
��Wrap=�6$   ��68   �� $ AdmArea: {0}��$ AdmArea��� 5"      $ 2q�6   $
��Wrap=�6$   ��68   �� $ District: {0}��$ District��� 5#      $ 2q�6   $
��Wrap=�6$   ��68   �� $ Address: {0}��$ Address��� 5$      $ 2q�6   $
��Wrap=�6$   ��68   �� $ FacilityArea: {0}��$ FacilityArea��� 5%      $ 2q�6   $
��Wrap=�6$   ��68   �� $ ObjectType: {0}��$ 
ObjectType��� 5&      $ 2q�6   $
��Wrap=�6$   ��68   �� $ PeriodOfPlacement: {0}��$ PeriodOfPlacement��� 5'      $ 2q�6   $
��Wrap=�6$   ��68   �� $ NameOfBusinessEntity: {0}��$ NameOfBusinessEntity�5(      5)      5*      