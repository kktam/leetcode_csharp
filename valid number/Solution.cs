/*
 *
 * Validate if a given string is numeric.
 *
 * Some examples:
 * "0" => true
 * " 0.1 " => true
 * "abc" => false
 * "1 a" => false
 * "2e10" => true
 */

public class Solution {
    public bool IsNumber(string s) {
		int i = 0;
        int n = s.Length;
		
        // Skip leading white spaces
        while (i < n && s[i] == ' ') {
            i++;
        }
        // Skip leading + and - signs
        while (i < n && ( s[i] == '+' || s[i] == '-')) {
            i++;
        }
        bool isNumeric = false;		
        // Skip leading numeric digit until 
		// exponent, decimal dot,
        while (i < n && ( Char.IsDigit(s, i) ) ) {
            i++;
			isNumeric = true;
        }
		// check for exponent exponent, decimal dot
		bool isDot = false;
		bool isExp = false;
		while (i < n) {
			char c = s[i];
			if (c == '.') {
				i++;
				if (!isDot) {
					isDot = true;
					isNumeric = true;					
				} else {
					isNumeric = false;
				}
                break;
			} else if (c == 'e' || c == 'E') {
				// is exponent, check for + or -
				i++;
				char c2 = s[i];
				if (c2 == '+' || c2 =='-') {
					i++;
                    if (!isExp) {
				        isExp = true;
					    isNumeric = true;
                    } else {
					    isNumeric = false;	                        
                    }
				} else {
					isNumeric = false;						
				}
                break;
			}  
		}
		
        // Remove trailing white spaces
        while (i < n && s[i] == ' ') {
            i++;
        }

		return isNumeric && (i == n);
    }
}