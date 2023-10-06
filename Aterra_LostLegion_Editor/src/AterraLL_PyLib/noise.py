# ----------------------------------------------------------------------------------------------------------------------
# - Package Imports -
# ----------------------------------------------------------------------------------------------------------------------
# General Packages
from __future__ import annotations
from typing import Any
import numpy as np
from attrs import field, define

# Custom Library

# Custom Packages

# ----------------------------------------------------------------------------------------------------------------------
# - Support Code -
# ----------------------------------------------------------------------------------------------------------------------
def _fade(t):
    # smooths the interpolation between gradient values
    return t * t * t * (t * (t * 6 - 15) + 10)

def _linear_interpolate(t, a, b):
    return a + t * (b - a)

def _gradient(hash, x, y):
    h = hash & 15
    grad = 1.0 + (h & 7)  # Gradient value between 1 and 2
    if h & 8:
        grad = -grad  # Randomly invert half of the gradients
    return grad * x + grad * y

# ----------------------------------------------------------------------------------------------------------------------
# - Code -
# ----------------------------------------------------------------------------------------------------------------------
@define
class NoisePerlin:
    # based on https://en.wikipedia.org/wiki/Perlin_noise#Implementation

    length:int
    width:int
    scale:int = 2
    seed:None | bool | int | float = None

    # These are best set after the seed has been defined
    perm_array: np.ndarray[Any, np.dtype] = field(init=False)

    def __attrs_post_init__(self):
        # Generate a random permutation array](www.help.com) based on the seed
        if self.seed is not None:
            np.random.seed(self.seed)

        perm_array = np.arange(256, dtype=int)
        np.random.shuffle(perm_array)
        self.perm_array = np.tile(perm_array, 2)

    def perlin_noise(self, x, y):
        X = int(x) & 255
        Y = int(y) & 255
        x -= int(x)
        y -= int(y)
        u = _fade(x)
        v = _fade(y)

        A = self.perm_array[X] + Y
        B = self.perm_array[X + 1] + Y

        return _linear_interpolate(v, _linear_interpolate(u, _gradient(self.perm_array[A], x, y),
                                                          _gradient(self.perm_array[B], x - 1, y)),
                                   _linear_interpolate(u, _gradient(self.perm_array[A + 1], x, y - 1),
                                                       _gradient(self.perm_array[B + 1], x - 1, y - 1)))

    def generate(self):
        noise = np.zeros((self.length, self.width))
        for i in range(self.length):
            for j in range(self.width):
                x = i / self.scale
                y = j / self.scale
                noise[i][j] = self.perlin_noise(x, y)

        return noise

# ----------------------------------------------------------------------------------------------------------------------
# - Main -
# ----------------------------------------------------------------------------------------------------------------------
if __name__ == '__main__':
    import matplotlib.pyplot as plt

    # Increase resolution and reduce scale for smoother noise

    # Parameters for octave noise
    width = height = 512
    octaves = 6  # Number of octaves
    persistence = 0.5  # Persistence controls amplitude decrease between octaves
    scale_factor = 2  # Scale factor between octaves
    seed = 42
    scale = 10

    perlin = NoisePerlin(width, height, scale, seed)  # Use a scale of 1 for the base octave

    # Generate the Perlin noise map by overlaying octaves
    noise_map = np.zeros((width, height))
    amplitude = 1.0
    total_amplitude = 0.0

    for octave in range(octaves):
        # Generate the current octave
        octave_map = perlin.generate()

        # Add the octave to the result with adjusted amplitude
        noise_map += octave_map * amplitude

        # Update total amplitude for normalization
        total_amplitude += amplitude

        # Decrease amplitude for the next octave
        amplitude *= persistence

        # Scale down for the next octave
        perlin.scale *= scale_factor

    # Normalize the result
    noise_map /= total_amplitude

    # Display the noise map using Matplotlib with bicubic interpolation
    plt.imshow(noise_map, cmap='cividis', interpolation='bicubic')
    plt.colorbar()
    plt.title("Perlin Noise Map")
    plt.show()