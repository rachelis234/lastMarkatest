import { Tree } from '@angular-devkit/schematics';
import { Schema } from './schema';
/**
 * Add pre-built styles to the main project style file.
 */
export declare function addThemeToAppStyles(options: Schema): (tree: Tree) => Tree;
export declare function modifyAppComponentTemplate(): (tree: Tree) => Tree;
/**
 * Add pre-built styles to the main project style file.
 */
export declare function importThemeInStyles(theme: string): (tree: Tree) => Tree;
