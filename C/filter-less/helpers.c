#include "helpers.h"
#include <math.h>

// Convert image to grayscale
void grayscale(int height, int width, RGBTRIPLE image[height][width])
{
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            int red = image[i][j].rgbtRed;
            int green = image[i][j].rgbtGreen;
            int blue = image[i][j].rgbtBlue;
            int average = round((red + green + blue) / 3.0);

            image[i][j].rgbtRed = average;
            image[i][j].rgbtGreen = average;
            image[i][j].rgbtBlue = average;
        }
    }
}

// Convert image to sepia
void sepia(int height, int width, RGBTRIPLE image[height][width])
{
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            int red = image[i][j].rgbtRed;
            int green = image[i][j].rgbtGreen;
            int blue = image[i][j].rgbtBlue;

            int sepiared = round((0.393 * red) + (0.769 * green) + (0.189 * blue));
            int sepiagreen = round((0.349 * red) + (0.686 * green) + (0.168 * blue));
            int sepiablue = round((0.272 * red) + (0.534 * green) + (0.131 * blue));

            if (sepiared <= 255)
            {
                image[i][j].rgbtRed = sepiared;
            }
            else
            {
                image[i][j].rgbtRed = 255;
            }

            if (sepiagreen <= 255)
            {
                image[i][j].rgbtGreen = sepiagreen;
            }
            else
            {
                image[i][j].rgbtGreen = 255;
            }
            if (sepiablue <= 255)
            {
                image[i][j].rgbtBlue = sepiablue;
            }
            else
            {
                image[i][j].rgbtBlue = 255;
            }
        }
    }
}

// Reflect image horizontally
void reflect(int height, int width, RGBTRIPLE image[height][width])
{
    RGBTRIPLE temp;
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width / 2; j++)
        {
            temp = image[i][j];
            image[i][j] = image[i][width - j - 1];
            image[i][width - j - 1] = temp;
        }
    }
}

// Blur image
void blur(int height, int width, RGBTRIPLE image[height][width])
{
    return;
}
