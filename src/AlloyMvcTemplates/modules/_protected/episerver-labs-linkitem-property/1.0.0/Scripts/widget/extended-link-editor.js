define([
// Dojo
    "dojo/_base/declare",
    "epi-cms/widget/LinkEditor"
], function (
// Dojo
    declare,
    LinkEditor
) {
    return declare([LinkEditor], {
            postMixInProperties: function () {
                // summary:
                //		Initialize properties
                // tags:
                //    protected
                this.inherited(arguments);

                this._actions.splice(1, 1);
            }
    });
});
