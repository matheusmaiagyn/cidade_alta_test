   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.XWindowTable   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  WindowTable��5   	   $	��450��6   $
��1000��6*    � 
ResizeMode$ NoResize=�67   .��5	      � ���	#FFDFF4FF.+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5
         AlternatingRowBackground
 ��ح�   
IsReadOnly$ False��6N    �� AlternationCount$ 2��5         AutoGenerateColumns$ False��6$   $��	0,0,0,126q�6B   ���	#FFDFF4FF
���   �$��4��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 6%   	   Header$	 ID��60   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6>   �� *ID+  5      $	 100 6%   $
	 Name��61   
 6A   �� *Name+  5      $	 100 6%   $	 Description��61   
 6H   �� *Description+  5      $ 50 6%   $	 Penalty��60   
 6C   �� *	Penalty+  5      $ 80 6%   $	 
PrisonTime��60   
 6F   �� *
PrisonTime+  5      $	 100 6%   $	 StatusID��61   
 6E   �� *
StatusID+  5      $	 130 6%   $	 
CreateDate��61   
 6G   �� *
CreateDate+  5      $	 130 6%   $	 
UpdateDate��61   
 6G   �� *
UpdateDate+  5      $	 135 6%   $	 CreateUserID��61   
 6I   �� *CreateUserID+  5      $	 135 6%   $	 UpdateUserID��61   
 6I   �� *UpdateUserID+5      �� 5   
   -   5         ��Name$ BtnAtualizar��5      $��	Atualizar��6'   $
��Left=�6;   $��
30,316,0,0q�6V   $	��Top=�6j   $��70��6�   ���	#FFBFBFBF
�������6�   �� 5   
   -   5        $ 	BtnSalvar��5      $��Salvar��6$   $
��Left=�65   $��130,316,0,0q�6P   $	��Top=�6e   $��70��6}   
����������	#FFBFBFBF6�   �� 5   
   -   5        $ BtnNovo��5      $
��Novo��6"   $
��Left=�61   $��230,316,0,0q�6L   $	��Top=�6a   $��70��6y   
����������	#FFBFBFBF6�   �� 5   
   -   5        $ 
BtnExcluir��5      $��Excluir��6%   $
��Left=�67   $��330,316,0,0q�6R   $	��Top=�6g   $��70��6   
����������	#FFBFBFBF6�   �� 5   
   -   5         ��Name$ TxtSearchID��5      $
��Left=�6'   $��430,316,0,0q�6B    �� TextWrapping$
 Wrap=�6W   $��Procurar por ID��6k   $	��Top=�6�   $	��160��6�   $��20��6�   6�   �� 5    
   -   5        $ 	BtnVoltar��5       $��Voltar��6$   $��Right=�65   $��0,316,130,0q�6Q   $	��Top=�6f   $��70��6~   ���	#FFBFBFBF
�������6�   �� 5!   
   -   5        $ 
BtnAvancar��5!      $��Avançar��6%   $��Right=�67   $��
0,316,30,0q�6S   $	��Top=�6g   $��70��6   ���	#FFBFBFBF
�������6�   �� 5"   
   -	   5        $ 	BtnLogout��5"      $��Logout��6$   $��Center=�65   $��	0,387,0,0q�6R   $	��Top=�6e   $��70��6}    J� RenderTransformOrigin$ -1.338,1.079&�6�   
����������	#FFBFBFBF6�   �� 5#   
   -
   5         ��Name$ DropDown��5#      $
��Left=�6%   $��630,316,0,0q�6@   $	��Top=�6U   $	��120��6m   $ 0.5,0.5&�6y   $��20��6�   z�5$      V� 5%      .~�5&      �� �� 5'       �� AngleX$ -1.195Q�6$   �� 5(      T� 5)       T� X$ -0.229Q�6)   5*      5,      5.      5/      