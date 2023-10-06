# ----------------------------------------------------------------------------------------------------------------------
# - Package Imports -
# ----------------------------------------------------------------------------------------------------------------------
# General Packages
from __future__ import annotations
import dearpygui.dearpygui as dpg

# Custom Library

# Custom Packages
import AterraLostLegionEditor as ALLE

# ----------------------------------------------------------------------------------------------------------------------
# - Code -
# ----------------------------------------------------------------------------------------------------------------------
def main():
    dpg.create_context()
    dpg.create_viewport(title='Aterra - Lost Legion - Editor')

    wnd_edit_area:int|str = ALLE.window_editor_area()

    dpg.set_primary_window(wnd_edit_area, True)

    dpg.setup_dearpygui()
    dpg.show_viewport()
    dpg.start_dearpygui()
    dpg.destroy_context()
    return

# ----------------------------------------------------------------------------------------------------------------------
if __name__ == '__main__':
    main()

