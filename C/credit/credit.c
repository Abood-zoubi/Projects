#include <cs50.h>
#include <stdio.h>

int main(void)
{
 long score = get_long("Number: ");
 while(score)
 {
    int count = 0;
    printf("%li\n", score % 10);
    count++;
    int x = floor(log10(n))+1;
    int array[x] = (score /= 10);
    int loop;

    for(loop = 9; loop >= 0; loop--)
    {
    printf("%d ", array[loop]);
    }




 }
}
// if (score < 1)
//     {
//         printf("HI");
//     }