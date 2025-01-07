#include <cs50.h>
#include <stdio.h>

int main(void)
{
    // Gets start size and insures it does not start below 9
    int size;
    do
    {
        size = get_int("Size: ");
    }
    while (size < 9);

    // Gets end size and insures it does not end below start size
    int end;
    do
    {
        end = get_int("End: ");
    }
    while (end < size);

    if (size == end)
    {
        printf("Years: 0");
    }

    // Calculates the number of years for start size to get to end size
    int born;
    int deaths;
    int total = 0;
    do
    {
        born = size / 3;
        deaths = size / 4;

        size = size + born - deaths;
        total ++;
    }
    while (size < end);

    //Prints total years
    printf("Years: %i\n", total);

}
