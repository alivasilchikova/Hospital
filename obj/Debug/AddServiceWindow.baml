   M S B A M L   `   `   `  ����F  BHospitalApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:HospitalAppHospitalApp  5   	   3clr-namespace:HospitalApp.DataHospitalApp.Data  5   	   "    HospitalApp.AddServiceWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:HospitalApp     5   	   5
viewModelsclr-namespace:HospitalApp.Data     5   	     � Title$  AddServiceWindow��5	   	   $	��250��6"   $	��350��6/   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��100* �6    � RowDefinitions 5   
   �� 5      $	��80* �6   �� 5      $	��20* �6   .+�5   
   �� $4��.Ввведите название услуги��6   $��5,10,0,0q�64   �� 5   
   $��10,40,70,110q�6/   ��6   �� *ServiceName+6/   �� 5   
   $,��&Ввведите цену услуги��6   $��5,80,0,0q�60   �� 5   
   $��10,110,70,40q�6(   ��6   �� *Cost+6(   �� 5   
   $��Добавить��6   $��5,5,0,0q�6%   $��1��66   $
��Left=�6C   $	��Top=�6^   $��85��6v   $��1��6�   ��6�   �� *CloseWindowCommand+6�   5      5      