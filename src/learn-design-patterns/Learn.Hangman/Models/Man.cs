using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Hangman.Models
{
    public class Man
    {
        string stage_0 = @"                          
                               -----------         
                              |           |        
                              |           |        
                              |             
                              |            
                              |          
                              |
                              |                  
                              |               
                              |               
                              |                   
                              |                    
                              |                 
                              |               
                          _________                 ";

        string stage_1 = @"                          
                               -----------         
                              |           |        
                              |           |        
                              |          ____      
                              |         /    \     
                              |         \    /     
                              |          \__/      
                              |                   
                              |                  
                              |                  
                              |                    
                              |                    
                              |                 
                              |              
                          _________                 ";

        string stage_2 = @"                          
                               -----------         
                              |           |        
                              |           |        
                              |          ____      
                              |         /    \     
                              |         \    /     
                              |          \__/      
                              |           |        
                              |           |       
                              |           |       
                              |           |         
                              |           |         
                              |                
                              |               
                          _________                 ";

        string stage_3 = @"                          
                               -----------         
                              |           |        
                              |           |        
                              |          ____      
                              |         /    \     
                              |         \    /     
                              |          \__/      
                              |           |        
                              |           |\       
                              |           | \      
                              |           |         
                              |           |         
                              |                
                              |              
                          _________                 ";

        string stage_4 = @"                          
                               -----------         
                              |           |        
                              |           |        
                              |          ____      
                              |         /    \     
                              |         \    /     
                              |          \__/      
                              |           |        
                              |          /|\       
                              |         / | \      
                              |           |         
                              |           |         
                              |               
                              |             
                          _________                 ";

        string stage_5 = @"                          
                               -----------         
                              |           |        
                              |           |        
                              |          ____      
                              |         /    \     
                              |         \    /     
                              |          \__/      
                              |           |        
                              |          /|\       
                              |         / | \      
                              |           |         
                              |           |         
                              |            \       
                              |             \      
                          _________                 ";

        string stage_6 = @"                          
                               -----------         
                              |           |        
                              |           |        
                              |          ____      
                              |         /    \     
                              |         \    /     
                              |          \__/      
                              |           |        
                              |          /|\       
                              |         / | \      
                              |           |         
                              |           |         
                              |          / \       
                              |         /   \      
                          _________                 ";
        public string GetMan(int stage)
        {
            switch (stage)
            {
                case 0: return stage_0;
                case 1: return stage_1;
                case 2: return stage_2;
                case 3: return stage_3;
                case 4: return stage_4;
                case 5: return stage_5;
                case 6: return stage_6;
                default: return stage_0;
            }
        }
    }
}
