namespace Learn.Hangman.Models
{
    public class Man
    {
        string case0 = @"                          
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

        string case1 = @"                          
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

        string case2 = @"                          
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

        string case3 = @"                          
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

        string case4 = @"                          
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

        string case5 = @"                          
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

        string case6 = @"                          
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
        public string GetMan(int fail)
        {
            switch (fail)
            {
                case 0: return case0;
                case 1: return case1;
                case 2: return case2;
                case 3: return case3;
                case 4: return case4;
                case 5: return case5;
                case 6: return case6;
                default: return case0;
            }
        }
    }
}
