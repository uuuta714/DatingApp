import { CanDeactivateFn } from '@angular/router';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';
import { ConfirmService } from '../_services/confirm.service';
import { inject } from '@angular/core';

// Select compnent as a type of CanDeactivate, then we have an access to the component
export const preventUnsavedChangesGuard: CanDeactivateFn<MemberEditComponent> = (component) => {
  const confirmService = inject(ConfirmService);
  
  if (component.editForm?.dirty) {
    return confirmService.confirm() ?? false;
  }
  return true;
};
