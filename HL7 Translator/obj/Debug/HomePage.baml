   M S B A M L   `   `   `  ����I  EHL7 Translator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HL7_TranslatorHL7_Translator  5          HL7_Translator.HomePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:HL7_Translator     5      $	��450��5      $	��650��6&   $��Bottom=�62   $��Center=�6M     N� Title$
  Home��5       N� FontSize$ 16(�6    � 	Resources 5	         styleCalendar �� 
TargetType&   System.Windows.Controls.Calendar �� Property �� Value �� 
TargetType5  /System.Windows.Controls.Primitives.CalendarItem  Name��%  &	        �� 5
   
   "  6&   .�5      ��  � �� 5      �� 5      "  6&   .R�5      (� $	��300��6"   $	��300��5   "   .��5        $ PART_CalendarItem��6+   #��z��5   +   #��z��5   +   #��z��5   +   5      5      5      5      5      .��5      � .+�5   
   �� -   5        $��TranslateButton��5      $%��Choose HL7 File For Translation��6(   $��Center=�6R   $��	0,226,0,0q�6o   $	��Top=�6�   $	��235��6�   $��53��6�   6�   �� 5   
   $��
Batch Date��6   $
��Left=�6%   $��186,101,0,0q�6@   $	��Top=�6U   $
��Bold"�6m   �� 5   
   $��Batch Number��6   $
��Left=�6'   $��186,148,0,0q�6B   $	��Top=�6W   $
��Bold"�6o   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��BatchDatePicker��5      $
��Left=�6,   $��325,102,0,0q�6G   $	��Top=�6\   $	��133��6t   $��30��6�      CalendarStyle# [  6�   �� 5    
   -   5        $��BatchNumberComboBox��5       $
��Left=�6.   $��325,152,0,0q�6I   $	��Top=�6^   $	��133��6v   .@�5!      �� $��1��6   $
��Left=�6'   $	��118��6B   �� 5"      $��2��6   $
��Left=�6'   $	��118��6B   �� 5#      $��3��6   $
��Left=�6'   $	��118��6B   �� 5$      $��4��6   $
��Left=�6'   $	��118��6B   �� 5%      $��5��6   $
��Left=�6'   $	��118��6B   �� 5&      $��6��6   $
��Left=�6'   $	��118��6B   �� 5'      $��7��6   $
��Left=�6'   $	��118��6B   �� 5(      $��8��6   $
��Left=�6'   $	��118��6B   �� 5)      $��9��6   $
��Left=�6'   $	��118��6B   �� 5*      $��10��6   $
��Left=�6(   $	��118��6C   �� 5+      $��11��6   $
��Left=�6(   $	��118��6C   �� 5,      $��12��6   $
��Left=�6(   $	��118��6C   �� 5-      $��13��6   $
��Left=�6(   $	��118��6C   �� 5.      $��14��6   $
��Left=�6(   $	��118��6C   �� 5/      $��15��6   $
��Left=�6(   $	��118��6C   50      �� 51   
   $J��DEnter the batch date and batch number of the results to be converted��6   $��Center=�6_   $��0,7,0,0q�6|   $	��Top=�6�   $
��Bold"�6�   $	��539��6�   �� 52   
   $��WrapWithOverflow=�6   $��Bottom=�64   $��11(�6O   $��
24,0,28,52q�6]   $��Center=�6q   ��* Select your source file folder (HL7 File), and your destination file (.txt file) folders by clicking on the "Settings" menu above54      �� 55   
   $��WrapWithOverflow=�6   $��Bottom=�64   $��11(�6O   $��64,0,526,16q�6]   �� 6t   $�Version 1.1��6x   6�   �� 56   
   $��WrapWithOverflow=�6   $��Bottom=�64   $��11(�6O   $��495,0,63,16q�6]   �� 6t   $�© 2018 Entromed��6x   6�   57      58      