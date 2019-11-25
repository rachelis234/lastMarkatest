import { Rule } from '@angular-devkit/schematics';
import { Schema as NgNewSchema } from '@schematics/angular/ng-new/schema';
import { Schema } from './schema';
/**
 * Scaffolds the basics of a PrimeNG application, this includes:
 *  - Add Packages to package.json
 *  - Adds pre-built themes to styles.ext
 *  - Adds Browser Animation to app.momdule
 */
export default function (options: Schema & NgNewSchema): Rule;
