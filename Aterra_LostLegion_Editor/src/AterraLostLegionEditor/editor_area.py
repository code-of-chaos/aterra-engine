# ----------------------------------------------------------------------------------------------------------------------
# - Package Imports -
# ----------------------------------------------------------------------------------------------------------------------
# General Packages
from __future__ import annotations
import dearpygui.dearpygui as dpg

# Custom Library

# Custom Packages

# ----------------------------------------------------------------------------------------------------------------------
# - Code -
# ----------------------------------------------------------------------------------------------------------------------
def window_editor_area() -> int|str:
    with dpg.window(label="Area Editor Window") as wnd_editor_area:

        # Set up the generation of the map
        dpg.add_text("Hello, world")
        dpg.add_input_int(label="x", default_value=3)
        dpg.add_input_int(label="y", default_value=3)

        dpg.add_button(label="generate")

    return wnd_editor_area