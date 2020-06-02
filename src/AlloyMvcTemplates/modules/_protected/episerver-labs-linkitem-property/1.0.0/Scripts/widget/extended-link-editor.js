define([
// Dojo
    "dojo/_base/declare",
    "epi-cms/widget/overlay/ItemCollection"
], function (
// Dojo
    declare,
    ItemCollection
) {
    return declare([ItemCollection], {
        // summary:
        //      The new overlay item for property LinkItem.
        // description:
        //      Drag and drop page/media to create new link
        // tags:
        //      internal

        onDrop: function (target, value) {
            // summary:
            //      Handles onDrop and add new value to model then raise onValueChange event to save this.
            // target: [Object]
            //      The dnd target.
            // value: [Object || Array]
            //      The dnd data.
            // tags:
            //      protected

            this.model.clear();
            this.inherited(arguments);
        }
    });
});
