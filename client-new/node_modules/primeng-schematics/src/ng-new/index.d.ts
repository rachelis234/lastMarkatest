import { Rule } from '@angular-devkit/schematics';
import { Schema as NgNewSchema } from '@schematics/angular/ng-new/schema';
import { Schema } from './schema';
/**
 * Combines Angular ng-new and PrimeNG ng-add schematics
 */
export default function (options: Schema & NgNewSchema): Rule;
