#include "helpers.h"

void colorize(int height, int width, RGBTRIPLE image[height][width])
{
    for(int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            if (image[height][width].rgbtRed == 0x00 || image[height][width].rgbtGreen == 0x00 || image[height][width].rgbtBlue == 0x00)
            {
                image[height][width].rgbtGreen = 0x4E;
            }
        }
    }
}
