#include <cs50.h>
#include <ctype.h>
#include <math.h>
#include <stdio.h>
#include <string.h>

// float count_letters(string text);
// float count_sentences(string text);
// float count_words(string text);

int count_letters(string text);
int count_words(string text);
int count_sentences(string text);

int main(void)
{
    string text = get_string("Text: ");
    int letters = count_letters(text);
    int words = count_words(text);
    int sentences = count_sentences(text);

    float L = (float) letters / (float) words * 100;
    float S = (float) sentences / (float) words * 100;

    int index = round(0.0588 * L - 0.296 * S - 15.8);

    if (index <= 0)
    {
        printf("Before Grade 1\n");
    }

    else if (index >= 16)
    {
        printf("Grade 16+\n");
    }
    else
    {

        printf("Grade %i\n", index);
    }
}

int count_letters(string text)
{
    int letters = 0;
    int len = strlen(text);
    for (int i = 0; i < len; i++)
    {
        if (isalpha(text[i]))
        {
            letters++;
        }
    }
    return letters;
}

int count_words(string text)
{
    int words = 1;
    int len = strlen(text);
    for (int i = 0; i < len; i++)
    {
        if (isspace(text[i]))
        {
            words++;
        }
    }
    return words;
}

int count_sentences(string text)
{
    int sentences = 0;
    int len = strlen(text);
    for (int i = 0; i < len; i++)
    {
        if (text[i] == '.' || text[i] == '!' || text[i] == '?')
        {
            sentences++;
        }
    }
    return sentences;
}

//     string text = get_string("Text: ");

//     int letters = count_letters(text);
//     printf("%i\n",letters);
//     // int words = count_words(text);
//     // int sentences = count_sentences(text);

//     // float L = (float) letters / (float) words * 100;
//     // float S = (float) sentences / (float) words * 100;

//     // int index = round(0.0588 * L - 0.296 * S - 15.8);

//     // if (index < 1)
//     // {
//     //     printf("Before Grade 1\n");
//     // }
//     // else if (index >= 16)
//     // {
//     //     printf("Grade 16+\n");
//     // }
//     // else
//     // {
//     //     printf("Grade %i\n", index);
//     // }
// }

// float count_letters(string text)
// {
//     int sentences = 0;
//     int words = 0;
//     int len = strlen(text);
//     int letters = 0;
//     for (int i = 0; i < len; i++)
//     {
//         if (isalpha(text[i]))
//         {
//             letters += 1;
//         }
//         else if (ispunct(text[i]))
//         {
//             sentences += 0;
//         }
//         else if (isspace(text[i]))
//         {
//             words += 1;
//         }
//     }
//     float L = (float) letters / (float) words * 100;

//     float S = (float) sentences / (float) words * 100;
//     int index = round(0.0588 * L - 0.296 * S - 15.8);

//     return index;
// }

// float count_sentences(string text)
// {
//     int sentences = 0;
//     int len = strlen(text);
//     for (int i = 0; i < len; i++)
//     {
//         if (ispunct(text[i]))
//         {
//             sentences += 1;
//         }
//         else
//         {
//             sentences += 0;
//         }
//     }
//     // if (sentences == 0)
//     // {
//     //     return sentences + 1;
//     // }
//     // else
//     // {
//     return sentences + 1;
//     // }
// }

// float count_words(string text)
// {
//     int words = 1;
//     int len = strlen(text);

//     for (int i = 0; i < len; i++)
//     {
//         if (isspace(text[i]))
//         {
//             words += 1;
//         }
//         else
//         {
//             words += 0;
//         }
//     }

//     return words;
// }