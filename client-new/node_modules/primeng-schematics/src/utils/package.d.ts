import { Tree } from '@angular-devkit/schematics';
/**
 * Adds a package to the package.json
 */
export declare function addPackageToPackageJson(tree: Tree, type: string, pkg: string, version: string): Tree;
/**
 * Adds a png alias to the package.json's scripts
 */
export declare function addPngAliasToPackageJson(tree: Tree): Tree;
