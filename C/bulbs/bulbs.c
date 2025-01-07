#include <cs50.h>
#include <stdio.h>
#include <string.h>

const int BITS_IN_BYTE = 8;

void print_bulb(int bit);
void decimal_to_binary(string text);

int main(void)
{
    string text = get_string("Message: ");
    decimal_to_binary(text);
}

void print_bulb(int bit)
{
    if (bit == 0)
    {
        // Dark emoji
        printf("\U000026AB");
    }
    else if (bit == 1)
    {
        // Light emoji
        printf("\U0001F7E1");
    }
}

void decimal_to_binary(string text)
{
    int len = strlen(text);
    for (int i = 0; i < len; i++)
    {
        int binary[] = {0, 0, 0, 0, 0, 0, 0, 0};
        int decimal_form = text[i];

        for (int j = 0; decimal_form > 0; j++)
        {
            binary[j] = decimal_form % 2;
            decimal_form = decimal_form / 2;
        }

        for (int b = BITS_IN_BYTE - 1; b >= 0; b--)
        {
            print_bulb(binary[b]);
        }
        printf("\n");
    }
}