import { CanDeactivateFn } from '@angular/router';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';

// Select compnent as a type of CanDeactivate, then we have an access to the component
export const preventUnsavedChangesGuard: CanDeactivateFn<MemberEditComponent> = (component) => {
  if (component.editForm?.dirty) {
    return confirm('Are you sure you want to continue? Any unsaved changes will be lost')
  }
  return true;
};
